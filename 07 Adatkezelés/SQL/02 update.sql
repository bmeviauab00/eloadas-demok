USE SzoftechDB

-- 2-es azonos�t�j� term�k nev�nek �s �r�nak m�dos�t�sa

--UPDATE Termek SET Nev = 'Termek2 �j', Ar = 220 WHERE TermekID = 2

-- 300 Ft-n�l olcs�bb term�kek �r�nak n�vel�se
UPDATE Termek SET Ar = Ar*1.2 WHERE Ar < 300

GO


