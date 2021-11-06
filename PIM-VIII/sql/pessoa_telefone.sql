CREATE TABLE pessoa_telefone (
	id_pessoa INTEGER NOT NULL UNIQUE,
	id_telefone INTEGER NOT NULL UNIQUE,
	PRIMARY KEY(id_pessoa, id_telefone)
	FOREIGN KEY(id_pessoa) REFERENCES pessoa(id)
	FOREIGN KEY(id_telefone) REFERENCES telefone(id)
)
