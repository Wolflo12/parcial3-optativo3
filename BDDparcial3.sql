-- This script was generated by the ERD tool in pgAdmin 4.
-- Please log an issue at https://github.com/pgadmin-org/pgadmin4/issues/new/choose if you find any bugs, including reproduction steps.
BEGIN;


CREATE TABLE IF NOT EXISTS public."Cliente"
(
    id integer NOT NULL,
    idbanco integer NOT NULL,
    nombre character varying(50),
    apellido character varying,
    documento character varying(50),
    direccion character varying(50),
    mail character varying(50),
    celular character varying(50),
    estado character varying(50),
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public."Factura"
(
    id integer NOT NULL,
    id_cliente integer NOT NULL,
    "Id_sucursal" integer NOT NULL,
    nro_factura character varying(50),
    fecha_hora character varying(50),
    total character varying(50),
    total_iva5 character varying(50),
    total_iva10 character varying(50),
    total_letras character varying(50),
    sucursal character varying(50),
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public."Sucursal"
(
    "Id" integer NOT NULL,
    "Direccion" character varying(100),
    "Telefono" character varying(10),
    "Whatsapp" character varying(10),
    "Mail" character varying(50),
    "Estado" character varying(50),
    PRIMARY KEY ("Id")
);

CREATE TABLE IF NOT EXISTS "Optativa".detalle_factura
(
    id integer,
    id_factura integer,
    id_producto integer,
    cantidad_producto character varying,
    subtotal character varying,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS "Optativa".producto
(
    id integer,
    descripcion character varying(50),
    cantidad_minima character varying(50),
    cantidad_stock character varying(50),
    precio_compra character varying(50),
    precio_venta character varying(50),
    marca character varying(50),
    estado character varying(50)
);

ALTER TABLE IF EXISTS public."Factura"
    ADD FOREIGN KEY (id_cliente)
    REFERENCES public."Cliente" (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS public."Factura"
    ADD FOREIGN KEY ("Id_sucursal")
    REFERENCES public."Sucursal" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS "Optativa".detalle_factura
    ADD FOREIGN KEY (id_factura)
    REFERENCES public."Factura" (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS "Optativa".detalle_factura
    ADD FOREIGN KEY (id_producto)
    REFERENCES "Optativa".producto (precio_compra) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;

END;