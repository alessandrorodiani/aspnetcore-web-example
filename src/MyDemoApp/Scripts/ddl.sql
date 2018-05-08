CREATE TABLE access (
    email varchar(50) CONSTRAINT pk_access PRIMARY KEY,
    password varchar(50) NOT NULL
);

INSERT INTO access(email,password) VALUES('pippo1@pippo.ch', '1234');
INSERT INTO access(email,password) VALUES('pippo2@pippo.ch', '1234');