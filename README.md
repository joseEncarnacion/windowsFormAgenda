# windowsFormAgenda

---Base de datos del proyecto 



create table persona(
	[idPersona] int primary key identity
      ,[nombre] varchar(50)
      ,[apellido] varchar(50)
      ,[nacimiento] date
      ,[dirreccion] varchar(50)
      ,[genero] varchar(50)
      ,[estadoCivil] varchar(50)
      ,[movil] varchar(50)
      ,[tell] varchar(50)
      ,[correo] varchar(50)

);
go
--insertar datos 
-- Insertar el primer conjunto de datos
INSERT INTO persona (nombre, apellido, nacimiento, dirreccion, genero, estadoCivil, movil, tell, correo)
VALUES ('Juan', 'Pérez', '1990-05-15', 'Calle 123', 'Masculino', 'Soltero', '123456789', '987654321', 'juan@email.com');
go
-- Insertar el segundo conjunto de datos
INSERT INTO persona (nombre, apellido, nacimiento, dirreccion, genero, estadoCivil, movil, tell, correo)
VALUES ('María', 'González', '1985-08-20', 'Avenida XYZ', 'Femenino', 'Casado', '987654321', '123456789', 'maria@email.com');
go
-- Insertar el tercer conjunto de datos
INSERT INTO persona (nombre, apellido, nacimiento, dirreccion, genero, estadoCivil, movil, tell, correo)
VALUES ('Carlos', 'López', '2000-03-10', 'Calle ABC', 'Masculino', 'Soltero', '555555555', '111111111', 'carlos@email.com');

--procedimiento almacenados

-- listar registro

create procedure sp_listar
as
Select * from dbo.persona

exec sp_listar


--Guardar registro

Create procedure sp_crear
@nom varchar(50),
@apell varchar(50),
@nac date,
@dir varchar(200),
@genero varchar(15),
@scivil varchar(15),
@movil varchar(15),
@tell varchar(15),
@correo varchar(50)
AS
BEGIN
    INSERT INTO dbo.persona
	([nombre]
      ,[apellido]
      ,[nacimiento]
      ,[dirreccion]
      ,[genero]
      ,[estadoCivil]
      ,[movil]
      ,[tell]
      ,correo
	  )
    VALUES (@nom, @apell, @nac, @dir, @genero, @scivil, @movil, @tell, @correo);
END


--actualizar

CREATE PROCEDURE sp_actualizarPorIdPersona
@idpersona INT,
@nom varchar(50),
@apell varchar(50),
@nac date,
@dir varchar(200),
@genero varchar(15),
@scivil varchar(15),
@movil varchar(15),
@tell varchar(15),
@correo varchar(50)
AS
BEGIN
    UPDATE dbo.persona
    SET
        [nombre] = @nom,      
        [apellido] = @apell,    
        [nacimiento] = @nac,       
        [dirreccion] = @dir,      
        [genero] = @genero,    
        [estadoCivil] = @scivil,
		[movil] = @movil,    
        [tell] = @tell,      
        correo = @correo     
    WHERE idpersona = @idpersona;
END




-- procedure para elimianr 

CREATE PROCEDURE sp_eliminarPorIdPersona
@idpersona INT
AS
BEGIN
    DELETE FROM dbo.persona
    WHERE idpersona = @idpersona;
END


