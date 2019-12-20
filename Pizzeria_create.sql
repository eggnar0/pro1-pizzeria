-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2019-12-20 16:53:49.073

-- tables
-- Table: Klient
CREATE TABLE Klient (
    id int  NOT NULL,
    imie varchar(255)  NOT NULL,
    nazwisko varchar(255)  NOT NULL,
    ulica varchar(255)  NOT NULL,
    nr_domu int  NOT NULL,
    nr_lokalu int  NULL,
    miasto varchar(255)  NOT NULL,
    telefon int  NOT NULL,
    email varchar(255)  NOT NULL,
    CONSTRAINT Klient_pk PRIMARY KEY  (id)
);

-- Table: Pizza
CREATE TABLE Pizza (
    id int  NOT NULL,
    pizza_id int  NOT NULL,
    wielkosc varchar(255)  NOT NULL,
    ciasto varchar(255)  NOT NULL,
    CONSTRAINT Pizza_pk PRIMARY KEY  (id)
);

-- Table: PizzaSkladnik
CREATE TABLE PizzaSkladnik (
    pizza_id int  NOT NULL,
    skladnik_id int  NOT NULL,
    CONSTRAINT PizzaSkladnik_pk PRIMARY KEY  (pizza_id,skladnik_id)
);

-- Table: PizzaSkladnikZamowienie
CREATE TABLE PizzaSkladnikZamowienie (
    zamowienie_id int  NOT NULL,
    PizzaSkladnik_id int  NOT NULL,
    CONSTRAINT PizzaSkladnikZamowienie_pk PRIMARY KEY  (zamowienie_id,PizzaSkladnik_id)
);

-- Table: PizzaTyp
CREATE TABLE PizzaTyp (
    id int  NOT NULL,
    nazwa int  NOT NULL,
    rabat_id int  NULL,
    cena int  NOT NULL,
    CONSTRAINT PizzaTyp_pk PRIMARY KEY  (id)
);

-- Table: Produkt
CREATE TABLE Produkt (
    id int  NOT NULL,
    nazwa varchar(255)  NOT NULL,
    kategoria varchar(255)  NOT NULL,
    cena int  NOT NULL,
    CONSTRAINT Produkt_pk PRIMARY KEY  (id)
);

-- Table: ProduktZamowienie
CREATE TABLE ProduktZamowienie (
    produkt_id int  NOT NULL,
    zamowienie_id int  NOT NULL,
    ilosc int  NOT NULL,
    CONSTRAINT ProduktZamowienie_pk PRIMARY KEY  (produkt_id,zamowienie_id)
);

-- Table: Rabat
CREATE TABLE Rabat (
    id int  NOT NULL,
    wielkosc int  NOT NULL,
    CONSTRAINT Rabat_pk PRIMARY KEY  (id)
);

-- Table: Skladnik
CREATE TABLE Skladnik (
    id int  NOT NULL,
    nazwa varchar(255)  NOT NULL,
    kategoria varchar(255)  NOT NULL,
    CONSTRAINT Skladnik_pk PRIMARY KEY  (id)
);

-- Table: Zamowienie
CREATE TABLE Zamowienie (
    id int  NOT NULL,
    klient_id int  NOT NULL,
    data datetime  NOT NULL,
    CONSTRAINT Zamowienie_pk PRIMARY KEY  (id)
);

-- foreign keys
-- Reference: DomyslneSkladniki_Pizza (table: PizzaSkladnik)
ALTER TABLE PizzaSkladnik ADD CONSTRAINT DomyslneSkladniki_Pizza
    FOREIGN KEY (pizza_id)
    REFERENCES PizzaTyp (id);

-- Reference: DomyslneSkladniki_Skladnik (table: PizzaSkladnik)
ALTER TABLE PizzaSkladnik ADD CONSTRAINT DomyslneSkladniki_Skladnik
    FOREIGN KEY (skladnik_id)
    REFERENCES Skladnik (id);

-- Reference: PizzaSkladnikZamowienie_PizzaSkladnik (table: PizzaSkladnikZamowienie)
ALTER TABLE PizzaSkladnikZamowienie ADD CONSTRAINT PizzaSkladnikZamowienie_PizzaSkladnik
    FOREIGN KEY (PizzaSkladnik_id)
    REFERENCES Pizza (id);

-- Reference: PizzaSkladnikZamowienie_Zamowienie (table: PizzaSkladnikZamowienie)
ALTER TABLE PizzaSkladnikZamowienie ADD CONSTRAINT PizzaSkladnikZamowienie_Zamowienie
    FOREIGN KEY (zamowienie_id)
    REFERENCES Zamowienie (id);

-- Reference: PizzaSkladnik_Pizza (table: Pizza)
ALTER TABLE Pizza ADD CONSTRAINT PizzaSkladnik_Pizza
    FOREIGN KEY (pizza_id)
    REFERENCES PizzaTyp (id);

-- Reference: Pizza_Rabat (table: PizzaTyp)
ALTER TABLE PizzaTyp ADD CONSTRAINT Pizza_Rabat
    FOREIGN KEY (rabat_id)
    REFERENCES Rabat (id);

-- Reference: ProduktZamowienie_Produkt (table: ProduktZamowienie)
ALTER TABLE ProduktZamowienie ADD CONSTRAINT ProduktZamowienie_Produkt
    FOREIGN KEY (produkt_id)
    REFERENCES Produkt (id);

-- Reference: ProduktZamowienie_Zamowienie (table: ProduktZamowienie)
ALTER TABLE ProduktZamowienie ADD CONSTRAINT ProduktZamowienie_Zamowienie
    FOREIGN KEY (zamowienie_id)
    REFERENCES Zamowienie (id);

-- Reference: Zamowienie_Klient (table: Zamowienie)
ALTER TABLE Zamowienie ADD CONSTRAINT Zamowienie_Klient
    FOREIGN KEY (klient_id)
    REFERENCES Klient (id);

-- End of file.

