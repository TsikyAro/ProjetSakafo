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
    salaire double precision not null,
    CONSTRAINT PK_famille PRIMARY KEY (idFamille)
);

CREATE TABLE membreFamille(
    idFamille varchar(10) REFERENCES famille(idFamille),
    idPersonne varchar(10) REFERENCES personne(idPersonne)
);
CREATE TABLE disponibilite (
    idDisponibilite varchar(10) NOT NULL DEFAULT 'D' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqDisponibilite AS varchar(7)), 7),
    idPersonne varchar(10) NOT NULL,
    leDate date NOT NULL,
    disponibilite int NOT NULL,
    CONSTRAINT PK_disponibilite PRIMARY KEY (idDisponibilite),
    CONSTRAINT FK_disponibilite_emploiDuTemp FOREIGN KEY (idPersonne) REFERENCES personne(idpersonne)
);

CREATE TABLE typeSakafo (
    idTypeSakafo varchar(10) NOT NULL DEFAULT 'TS' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqTypeSakafo AS varchar(7)), 7),
    nom varchar(30) NOT NULL,
    CONSTRAINT PK_typeSakafo PRIMARY KEY (idTypeSakafo)
);
insert into typeSakafo (nom) values ('Viande Blanche'),('Viande Rouge'),('Abbat'),('Legume Haut'),('Legume Bas'),('Accompagnement');

CREATE TABLE sakafo (
    idSakafo varchar(10) NOT NULL DEFAULT 'SKF' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqSakafo AS varchar(7)), 7),
    nom varchar(30) NOT NULL,
    idTypeSakafo varchar(10) NOT NULL,
    Prix double precision not null,
    CONSTRAINT PK_sakafo PRIMARY KEY (idSakafo),
    CONSTRAINT FK_sakafo_typeSakafo FOREIGN KEY (idTypeSakafo) REFERENCES typeSakafo(idTypeSakafo)
);
CREATE TABLE interdiction (
    idInterdiction varchar(10) NOT NULL DEFAULT 'ID' + RIGHT('0000000' + CAST(NEXT VALUE FOR seqInterdiction AS varchar(7)), 7),
    idSanter varchar(10) NOT NULL,
    idTypeSakafo varchar(10) REFERENCES typeSakafo(idTypeSakafo),
    CONSTRAINT PK_interdiction PRIMARY KEY (idInterdiction),
    CONSTRAINT FK_interdiction_santer FOREIGN KEY (idSanter) REFERENCES santer(idSanter)
);
create view single as select p.* from personne p left join membreFamille m on p.idPersonne = m.idPersonne where m.idFamille is null;
create view ViandeB as select * from sakafo where idTypeSakafo ='TS0000001' order by prix asc;
create view ViandeR as select * from sakafo where idTypeSakafo ='TS0000002' order by prix asc;
create view abbat as select * from sakafo where idTypeSakafo ='TS0000003' order by prix asc;
create view LegumeH as select * from sakafo where idTypeSakafo ='TS0000004' order by prix asc;
create view LegumeB as select * from sakafo where idTypeSakafo ='TS0000005' order by prix asc;
create view Accompagnement as select * from sakafo where idTypeSakafo ='TS0000006' order by prix asc;