
INSERT INTO Alunos (Nome, DataNascimento, NumeroMatricula, Email, Cpf, Senha)
VALUES ('João', datetime('now'), 1234, 'joao@gmail.com', '123.456.789-00', 'senha123'),
       ('Maria', datetime('now'), 5678, 'maria@gmail.com', '987.654.321-99', 'senha456'),
       ('Pedro', datetime('now'), 9101, 'pedro@gmail.com', '456.789.123-33', 'senha789');

-- Insert data into Arquivos table
INSERT INTO Arquivos (CaminhoArquivo, NomeOriginal, GuidArquivo)
VALUES ('/path/to/file1.pdf', 'file1.pdf', '123e4567-e89b-12d3-a456-426614174000'),
       ('/path/to/file2.pdf', 'file2.pdf', '123e4567-e89b-12d3-a456-426614174001');

-- Insert data into Logins table
INSERT INTO Logins (Cpf, Senha)
VALUES ('123.456.789-00', 'senha123'),
       ('987.654.321-99', 'senha456');

-- Insert data into Professores table
INSERT INTO Professores (Nome, DataNascimento, Cpf, Email, Senha)
VALUES ('João', datetime('now'), '123.456.789-00', 'joao@gmail.com', 'senha123'),
       ('Maria', datetime('now'), '987.654.321-99', 'maria@gmail.com', 'senha456');

-- Insert data into Tccs table
INSERT INTO Tccs (Tema, DataPublicacao, DataEntregaTCC, AreaEstudo, Arquivo, AlunoId, ProfessorId)
VALUES ('Tema 1', datetime('now'), datetime('now'), 'Computação', '/path/to/file1.pdf', 1, 1),
       ('Tema 2', datetime('now'), datetime('now'), 'Matemática', '/path/to/file2.pdf', 2, 2);