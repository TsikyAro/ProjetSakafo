CREATE SEQUENCE seqPersonne START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seqSanter START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seqEtat START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seqFamille START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seqEmploiDuTemp START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seqDisponibilite START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seqTypeSakafo START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seqSakafo START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seqPlat START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seqComposantPlat START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seqInterdiction START WITH 1 INCREMENT BY 1;


CREATE TABLE personne (
    idPersonne varchar(10) NOT NULL DEFAULT 'P' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqPersonne AS varchar(7)), 7),
    nom varchar(30) NOT NULL,
    dateDeNaissance date NOT NULL,
    CONSTRAINT PK_personne PRIMARY KEY (idPersonne)
);

CREATE TABLE santer (
    idSanter varchar(10) NOT NULL DEFAULT 'S' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqSanter AS varchar(7)), 7),
    nom varchar(30) NOT NULL,
    CONSTRAINT PK_santer PRIMARY KEY (idSanter)
);
insert into santer (nom) values ('Diabetique'),('Tensionaire'),('Zaza-mitombo'),('En regime');

CREATE TABLE etat (
    idEtat varchar(10) NOT NULL DEFAULT 'E' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqEtat AS varchar(7)), 7),
    idSanter varchar(10) NOT NULL,
    idPersonne varchar(10) not null,
    pourcentage int NOT NULL,
    CONSTRAINT PK_etat PRIMARY KEY (idEtat),
    CONSTRAINT FK_etat_santer FOREIGN KEY (idSanter) REFERENCES santer(idSanter),
    CONSTRAINT FK_etat_Personne FOREIGN KEY (idPersonne) REFERENCES personne(idPersonne)
);

CREATE TABLE famille (
    idFamille varchar(10) NOT NULL DEFAULT 'F' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqFamille AS varchar(7)), 7),
    nom varchar(30) NOT NULL,
    CONSTRAINT PK_famille PRIMARY KEY (idFamille)
);

CREATE TABLE membreFamille(
    idFamille varchar(10) REFERENCES famille(idFamille),
    idPersonne varchar(10) REFERENCES personne(idPersonne)
);

CREATE TABLE emploiDuTemp (
    idEmploiDuTemp varchar(10) NOT NULL DEFAULT 'EDT' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqEmploiDuTemp AS varchar(7)), 7),
    idPersonne varchar(10) NOT NULL,
    CONSTRAINT PK_emploiDuTemp PRIMARY KEY (idEmploiDuTemp),
    CONSTRAINT FK_emploiDuTemp_personne FOREIGN KEY (idPersonne) REFERENCES personne(idPersonne)
);

CREATE TABLE disponibilite (
    idDisponibilite varchar(10) NOT NULL DEFAULT 'D' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqDisponibilite AS varchar(7)), 7),
    idEmploiDuTemp varchar(10) NOT NULL,
    leDate date NOT NULL,
    disponibilite int NOT NULL,
    CONSTRAINT PK_disponibilite PRIMARY KEY (idDisponibilite),
    CONSTRAINT FK_disponibilite_emploiDuTemp FOREIGN KEY (idEmploiDuTemp) REFERENCES emploiDuTemp(idEmploiDuTemp)
);

CREATE TABLE typeSakafo (
    idTypeSakafo varchar(10) NOT NULL DEFAULT 'TS' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqTypeSakafo AS varchar(7)), 7),
    nom varchar(30) NOT NULL,
    CONSTRAINT PK_typeSakafo PRIMARY KEY (idTypeSakafo)
);

CREATE TABLE sakafo (
    idSakafo varchar(10) NOT NULL DEFAULT 'SKF' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqSakafo AS varchar(7)), 7),
    nom varchar(30) NOT NULL,
    idTypeSakafo varchar(10) NOT NULL,
    CONSTRAINT PK_sakafo PRIMARY KEY (idSakafo),
    CONSTRAINT FK_sakafo_typeSakafo FOREIGN KEY (idTypeSakafo) REFERENCES typeSakafo(idTypeSakafo)
);

CREATE TABLE plat (
    idPlat varchar(10) NOT NULL DEFAULT 'PL' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqPlat AS varchar(7)), 7),
    nom varchar(30) NOT NULL,
    CONSTRAINT PK_plat PRIMARY KEY (idPlat)
);

CREATE TABLE composantPlat (
    idComposantPlat varchar(10) NOT NULL DEFAULT 'CP' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqComposantPlat AS varchar(7)), 7),
    idPlat varchar(10) NOT NULL,
    idSakafo varchar(10) NOT NULL,
    CONSTRAINT PK_composantPlat PRIMARY KEY (idComposantPlat),
    CONSTRAINT FK_composantPlat_plat FOREIGN KEY (idPlat) REFERENCES plat(idPlat),
    CONSTRAINT FK_composantPlat_sakafo FOREIGN KEY (idSakafo) REFERENCES sakafo(idSakafo)
);

CREATE TABLE interdiction (
    idInterdiction varchar(10) NOT NULL DEFAULT 'ID' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqInterdiction AS varchar(7)), 7),
    idSanter varchar(10) NOT NULL,
    maximum double precision NOT NULL,
    CONSTRAINT PK_interdiction PRIMARY KEY (idInterdiction),
    CONSTRAINT FK_interdiction_santer FOREIGN KEY (idSanter) REFERENCES santer(idSanter)
);

create view single as select p.* from personne p left join membreFamille m on p.idPersonne = m.idPersonne where m.idFamille is null;