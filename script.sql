﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE SEQUENCE "SEQ_EVENTO" START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;

CREATE SEQUENCE "SEQ_USUARIO" START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;

CREATE SEQUENCE "SEQ_VOLUNTARIO" START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;

CREATE TABLE "USUARIOS" (
    "ID" integer NOT NULL,
    "NOME" character varying(150) NOT NULL,
    "EMAIL" character varying(150) NOT NULL,
    "SENHA" text NOT NULL,
    "DATA_NASCIMENTO" timestamp with time zone NOT NULL,
    "CIDADE" character varying(150) NOT NULL,
    "TELEFONE" integer NOT NULL,
    "SEXO" integer NOT NULL,
    CONSTRAINT "PK_USUARIOS" PRIMARY KEY ("ID")
);

CREATE TABLE "EVENTOS" (
    "ID" integer NOT NULL,
    "TITULO" character varying(200) NOT NULL,
    "DESCRICAO" character varying(500) NOT NULL,
    "CIDADE" text NOT NULL,
    "BAIRRO" text NOT NULL,
    "RUA" text NOT NULL,
    "NUMERO" text NOT NULL,
    "DATA_EVENTO" timestamp with time zone NOT NULL,
    "ORGANIZADOR_ID" integer NOT NULL,
    "QTD_VOLUNT_NEC" integer NOT NULL,
    "QTD_PARTICIPANTES" integer NOT NULL,
    CONSTRAINT "PK_EVENTOS" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_EVENTO_ORGANIZADOR" FOREIGN KEY ("ORGANIZADOR_ID") REFERENCES "USUARIOS" ("ID") ON DELETE CASCADE
);

CREATE TABLE "VOLUNTARIOS" (
    "ID" integer NOT NULL,
    "USUARIO_ID" integer NOT NULL,
    "EVENTO_ID" integer NOT NULL,
    CONSTRAINT "PK_VOLUNTARIOS" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_VOLUNTARIO_EVENTO" FOREIGN KEY ("EVENTO_ID") REFERENCES "EVENTOS" ("ID") ON DELETE CASCADE,
    CONSTRAINT "FK_VOLUNTARIO_USUARIO" FOREIGN KEY ("USUARIO_ID") REFERENCES "USUARIOS" ("ID") ON DELETE CASCADE
);

CREATE INDEX "IX_EVENTOS_ORGANIZADOR_ID" ON "EVENTOS" ("ORGANIZADOR_ID");

CREATE INDEX "IX_VOLUNTARIOS_EVENTO_ID" ON "VOLUNTARIOS" ("EVENTO_ID");

CREATE INDEX "IX_VOLUNTARIOS_USUARIO_ID" ON "VOLUNTARIOS" ("USUARIO_ID");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221109011905_CreateTable', '6.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE "USUARIOS" ADD "ESTADO" character varying(150) NOT NULL DEFAULT '';

ALTER TABLE "EVENTOS" ADD "Endereco_Estado" text NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221111004132_UpdateUsuariosAndEventos', '6.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE "USUARIOS" ALTER COLUMN "TELEFONE" TYPE character varying(15);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221111005448_UpdateTelefone', '6.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE "EVENTOS" DROP COLUMN "QTD_PARTICIPANTES";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221123232605_UpdateEventos', '6.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE "EVENTOS" ADD "CANCELADO" boolean NOT NULL DEFAULT FALSE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221124223640_CreateFieldCanceladoToEventos', '6.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE "USUARIOS" ADD "FOTO_PERFIL" character varying(500) NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221125223000_AddFotoPerfilToUsuarios', '6.0.10');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221127171818_FotoPerfilNotRequired', '6.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE "USUARIOS" ALTER COLUMN "FOTO_PERFIL" DROP NOT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221127195314_FotoPerfilIsRequiredFalse', '6.0.10');

COMMIT;

