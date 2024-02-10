USE SzoftechDB

-- 2-es azonosítójú termék nevének és árának módosítása

--UPDATE Termek SET Nev = 'Termek2 új', Ar = 220 WHERE TermekID = 2

-- 300 Ft-nál olcsóbb termékek árának növelése
UPDATE Termek SET Ar = Ar*1.2 WHERE Ar < 300

GO


