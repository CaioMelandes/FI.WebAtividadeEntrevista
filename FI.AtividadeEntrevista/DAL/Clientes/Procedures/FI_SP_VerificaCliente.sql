﻿CREATE PROC FI_SP_VerificaCliente
	@CPF		   VARCHAR (14)
AS
BEGIN
	SELECT ID FROM CLIENTES WHERE CPF = @CPF
END