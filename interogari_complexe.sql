-- Interogari complexe pentru baza de date a agentiei de turism
-- 1. Afiseaza toate excursiile care au un grad de umplere peste x%, descrescator in functie de x pentru data y

SELECT E.Denumire, (
					SELECT cast(cast(count(1) * 100.00 / E.NrMaximParticipanti as decimal(10, 2)) as nvarchar(6)) + '%'
					FROM Rezervare as R
					JOIN ClientRezervare as CR 
					ON R.IDRezervare = CR.IDRezervare	
					WHERE R.DataPlecare = '2021-04-21' and R.IDExcursie = E.IDExcursie
					) as ProcentOcupare
FROM Excursie as E
WHERE 10 < (
	SELECT count(1) * 100.00 / E.NrMaximParticipanti
	FROM Rezervare as R
	JOIN ClientRezervare as CR 
	ON R.IDRezervare = CR.IDRezervare	
	WHERE R.DataPlecare = '2021-04-21' and R.IDExcursie = E.IDExcursie
)
order by ProcentOcupare DESC

-- 2. Clientii care au cheltuit cel mai mult pe platforma (suma costurilor excursiilor) din data x pana in prezent

SELECT C.Nume, C.Prenume, SUM(E.PretBaza) as Total
FROM Client as C
JOIN ClientRezervare as CR ON C.IDClient = CR.IDClient
JOIN Rezervare as R on R.IDRezervare = CR.IDRezervare
JOIN Excursie as E on E.IDExcursie = R.IDExcursie
WHERE R.IDRezervare in (
						SELECT Rez.IDRezervare 
						FROM Rezervare as Rez 
						WHERE Rez.DataPlecare >= '2021-04-21')
GROUP BY C.Nume, C.Prenume
ORDER BY Total DESC

-- 3. Top x cele mai populare orase in functie de rezervari si in care exista maxim o excursie care duce acolo
SELECT TOP 3 D.Denumire, (
							SELECT COUNT(R.IDRezervare)
							FROM Rezervare as R
							WHERE R.IDExcursie = E.IDExcursie	
						 ) as TotalRezervari
FROM Destinatie as D
JOIN Excursie as E on E.IDDestinatie = D.IDDestinatie
WHERE 1 = (
			SELECT count(E2.IDExcursie)
			FROM Excursie as E2
			WHERE E2.IDDestinatie = D.IDDestinatie
			)
ORDER BY TotalRezervari DESC

-- 4. Cazarile unde nu s-au mai facut rezervari in ultimele x luni si costa peste y lei pe noapte
SELECT UC.Nume, D.Denumire, UC.PretNoapte
FROM UnitatiCazare as UC
JOIN Destinatie as D on D.IDDestinatie = UC.IDDestinatie 
WHERE UC.PretNoapte > 100
and
not exists (
		SELECT *
		FROM Rezervare as R
		WHERE R.IDCazare = UC.IDCazare
		and R.DataPlecare > '2021-04-21'
	 )
