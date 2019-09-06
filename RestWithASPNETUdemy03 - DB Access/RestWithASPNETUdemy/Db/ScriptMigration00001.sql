-- Table: public.persons

-- DROP TABLE public.persons;

CREATE TABLE public.persons
(
    "Id" bigint NOT NULL,
    "FisrtName" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "LastName" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "Gender" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT persons_pkey PRIMARY KEY ("Id")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.persons
    OWNER to udemy;