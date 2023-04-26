USE SzoftechDB

-- A Termek t�bla minden oszlop�nak list�z�sa (minden sorra)
--SELECT * 
--FROM Termek

-- A Termek t�bla TermekID �s Nev oszlop�nak list�z�sa (minden sorra)
--SELECT Nev, Ar 
--FROM Termek

--SELECT * 
--FROM Termek
--WHERE Ar > 400

--SELECT * 
--FROM Termek
--WHERE Ar > 400 OR Ar < 200

--SELECT * 
--FROM Termek
--WHERE Ar BETWEEN 200 AND 300

--SELECT * 
--FROM Termek
--WHERE GyartoID IS NOT NULL

--SELECT * 
--FROM Termek
--WHERE Nev LIKE '%m�k1'

----List�zzuk a gy�rt�kat, meg az �ltaluk gy�rtott �rucikkek neveit
--SELECT Gyarto.*, Termek.Nev AS TermekNev
--FROM Gyarto JOIN Termek ON Gyarto.GyartoID = Termek.GyartoID

---- List�zzuk a term�keket, de a gy�rt� nev�t is jelen�ts�k meg
--SELECT Termek.*, Gyarto.Nev AS GyartoNev
--FROM Termek JOIN Gyarto ON Termek.GyartoID = Gyarto.GyartoID
 
-- List�zzuk a term�keket, de a gy�rt� nev�t is jelen�ts�k meg,
-- �s vegy�k bele azon term�keket is, amikhez nincs gy�rt� 
-- rendelve.
--SELECT Termek.*, Gyarto.Nev AS GyartoNev
--FROM Termek LEFT OUTER JOIN Gyarto ON Termek.GyartoID = Gyarto.GyartoID


GO

