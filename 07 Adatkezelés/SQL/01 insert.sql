USE SzoftechDB

DELETE FROM Termek
DELETE FROM Gyarto

INSERT INTO Gyarto (GyartoID, Nev, Cim) VALUES (1, 'Gyártó1', 'Cím1')
INSERT INTO Gyarto (GyartoID, Nev, Cim) VALUES (2, 'Gyártó2', 'Cím2')
INSERT INTO Gyarto (GyartoID, Nev, Cim) VALUES (3, 'Gyártó3', 'Cím2')

INSERT INTO Termek (TermekID, Nev, Ar, GyartoID) VALUES (1, 'Termék1', 100, 1)
INSERT INTO Termek (TermekID, Nev, Ar, GyartoID) VALUES (2, 'Termék2', 200, 1)
INSERT INTO Termek (TermekID, Nev, Ar, GyartoID) VALUES (3, 'Termék3', 400, 2)
INSERT INTO Termek (TermekID, Nev, Ar, GyartoID) VALUES (4, 'Termék4', 400, null)

GO


