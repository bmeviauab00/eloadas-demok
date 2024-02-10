USE SzoftechDB

-- A Termek tábla minden oszlopának listázása (minden sorra)
--SELECT * 
--FROM Termek

-- A Termek tábla TermekID és Nev oszlopának listázása (minden sorra)
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
--WHERE Nev LIKE '%mék1'

----Listázzuk a gyártókat, meg az általuk gyártott árucikkek neveit
--SELECT Gyarto.*, Termek.Nev AS TermekNev
--FROM Gyarto JOIN Termek ON Gyarto.GyartoID = Termek.GyartoID

---- Listázzuk a termékeket, de a gyártó nevét is jelenítsük meg
--SELECT Termek.*, Gyarto.Nev AS GyartoNev
--FROM Termek JOIN Gyarto ON Termek.GyartoID = Gyarto.GyartoID
 
-- Listázzuk a termékeket, de a gyártó nevét is jelenítsük meg,
-- és vegyük bele azon termékeket is, amikhez nincs gyártó 
-- rendelve.
--SELECT Termek.*, Gyarto.Nev AS GyartoNev
--FROM Termek LEFT OUTER JOIN Gyarto ON Termek.GyartoID = Gyarto.GyartoID


GO

