CREATE TABLE pessoa (
	id	INTEGER NOT NULL UNIQUE,
	nome	TEXT NOT NULL,
	cpf	TEXT NOT NULL,
	endereco	INTEGER NOT NULL,
	PRIMARY KEY(id AUTOINCREMENT)
	FOREIGN KEY(endereco) REFERENCES endereco(id)
)
