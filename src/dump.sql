-- CREATE DATABASE telefonkonyv;
-- USE telefonkonyv;

CREATE TABLE nevek (
  id INT PRIMARY KEY IDENTITY,
  nev VARCHAR(100),
  tel VARCHAR(100));

INSERT INTO nevek VALUES
('Végh Béla',  '+36302902121'),
('Fütty Imre', '+36201112233'),
('Viz Elek',   '+36301010101');