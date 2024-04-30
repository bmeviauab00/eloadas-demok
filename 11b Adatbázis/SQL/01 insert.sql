USE SzoftechDB

DELETE FROM Termek
DELETE FROM Gyarto

INSERT INTO Gyarto (GyartoID, Nev, Cim) VALUES (1, 'Gy�rt�1', 'C�m1')
INSERT INTO Gyarto (GyartoID, Nev, Cim) VALUES (2, 'Gy�rt�2', 'C�m2')
INSERT INTO Gyarto (GyartoID, Nev, Cim) VALUES (3, 'Gy�rt�3', 'C�m2')

INSERT INTO Termek (TermekID, Nev, Ar, GyartoID) VALUES (1, 'Term�k1', 100, 1)
INSERT INTO Termek (TermekID, Nev, Ar, GyartoID) VALUES (2, 'Term�k2', 200, 1)
INSERT INTO Termek (TermekID, Nev, Ar, GyartoID) VALUES (3, 'Term�k3', 400, 2)
INSERT INTO Termek (TermekID, Nev, Ar, GyartoID) VALUES (4, 'Term�k4', 400, null)

GO


