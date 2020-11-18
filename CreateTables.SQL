-- Create tables section -------------------------------------------------

-- Table themes

CREATE TABLE "themes"
(
  "theme_id" Integer NOT NULL GENERATED ALWAYS AS IDENTITY
    (INCREMENT BY 1 NO MINVALUE NO MAXVALUE START WITH 1 CACHE 1),
  "theme_name" Character varying(20) NOT NULL,
  "theme_description" Text NOT NULL,
  "theme_creation_date" Date DEFAULT CURRENT_TIMESTAMP(2) NOT NULL,
  "theme_created_by" Integer NOT NULL,
  "theme_deleted" Boolean DEFAULT false NOT NULL,
  "theme_deletion_date" Date,
  "theme_deleted_by" Integer
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_Relationship1" ON "themes" ("theme_created_by")
;

CREATE INDEX "IX_Relationship2" ON "themes" ("theme_deleted_by")
;

ALTER TABLE "themes" ADD CONSTRAINT "PK_themes" PRIMARY KEY ("theme_id")
;

ALTER TABLE "themes" ADD CONSTRAINT "theme_id" UNIQUE ("theme_id")
;

ALTER TABLE "themes" ADD CONSTRAINT "theme_name" UNIQUE ("theme_name")
;

-- Table users

CREATE TABLE "users"
(
  "user_id" Integer NOT NULL GENERATED ALWAYS AS IDENTITY
    (INCREMENT BY 1 NO MINVALUE NO MAXVALUE START WITH 1 CACHE 1),
  "user_login" Character varying(20) NOT NULL,
  "user_password_salt" Integer NOT NULL,
  "user_password_hash" Character varying(50) NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "users" ADD CONSTRAINT "PK_users" PRIMARY KEY ("user_id")
;

ALTER TABLE "users" ADD CONSTRAINT "user_id" UNIQUE ("user_id")
;

ALTER TABLE "users" ADD CONSTRAINT "user_login" UNIQUE ("user_login")
;

-- Table products

CREATE TABLE "products"
(
  "product_id" Integer NOT NULL GENERATED ALWAYS AS IDENTITY
    (INCREMENT BY 1 NO MINVALUE NO MAXVALUE START WITH 1 CACHE 1),
  "product_decimal_number" Character varying(20) NOT NULL,
  "product_creation_date" Date DEFAULT CURRENT_TIMESTAMP(2) NOT NULL,
  "product_created_by" Integer NOT NULL,
  "product_deleted" Boolean DEFAULT false NOT NULL,
  "product_deletion_date" Date,
  "product_deleted_by" Integer
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_product_creator" ON "products" ("product_created_by")
;

CREATE INDEX "IX_product_deleter" ON "products" ("product_deleted_by")
;

ALTER TABLE "products" ADD CONSTRAINT "PK_products" PRIMARY KEY ("product_id")
;

ALTER TABLE "products" ADD CONSTRAINT "product_id" UNIQUE ("product_id")
;

ALTER TABLE "products" ADD CONSTRAINT "product_decimal_number" UNIQUE ("product_decimal_number")
;

-- Table theme_composition

CREATE TABLE "theme_composition"
(
  "theme_id" Integer NOT NULL,
  "product_id" Integer NOT NULL,
  "product_amount" Integer DEFAULT 0 NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "theme_composition" ADD CONSTRAINT "PK_theme_composition" PRIMARY KEY ("product_id","theme_id")
;

-- Table purchased_products

CREATE TABLE "purchased_products"
(
  "purchased_product_id" Integer NOT NULL GENERATED ALWAYS AS IDENTITY
    (INCREMENT BY 1 NO MINVALUE NO MAXVALUE START WITH 1 CACHE 1),
  "purchased_product_vendor" Character varying(30) NOT NULL,
  "purchased_product_vendor_code" Character varying(20) NOT NULL,
  "purchased_product_short_description" Character varying(20),
  "purchased_product_full_description" Text,
  "purchased_product_doc_link" Character varying(50),
  "purchased_product_creation_date" Date DEFAULT CURRENT_TIMESTAMP(2) NOT NULL,
  "purchased_product_created_by" Integer NOT NULL,
  "purchased_product_deleted" Boolean DEFAULT false NOT NULL,
  "purchased_product_deletion_date" Date,
  "purchased_product_deleted_by" Integer
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_purchased_product_creator" ON "purchased_products" ("purchased_product_created_by")
;

CREATE INDEX "IX_purchased_product_deleter" ON "purchased_products" ("purchased_product_deleted_by")
;

ALTER TABLE "purchased_products" ADD CONSTRAINT "PK_purchased_products" PRIMARY KEY ("purchased_product_id")
;

ALTER TABLE "purchased_products" ADD CONSTRAINT "purchased_product_id" UNIQUE ("purchased_product_id")
;

-- Table product_composition

CREATE TABLE "product_composition"
(
  "product_id" Integer NOT NULL,
  "purchased_product_id" Integer NOT NULL,
  "purchased_product_amount" Integer DEFAULT 0 NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "product_composition" ADD CONSTRAINT "PK_product_composition" PRIMARY KEY ("purchased_product_id","product_id")
;

-- Table requests

CREATE TABLE "requests"
(
  "request_id" Integer NOT NULL GENERATED ALWAYS AS IDENTITY
    (INCREMENT BY 1 NO MINVALUE NO MAXVALUE START WITH 1 CACHE 1),
  "request_name" Character varying(20) NOT NULL,
  "request_description" Text NOT NULL,
  "request_creation_date" Date DEFAULT CURRENT_TIMESTAMP(2) NOT NULL,
  "request_created_by" Integer
)
WITH (
  autovacuum_enabled=true)
;

CREATE INDEX "IX_request_author" ON "requests" ("request_created_by")
;

ALTER TABLE "requests" ADD CONSTRAINT "PK_requests" PRIMARY KEY ("request_id")
;

ALTER TABLE "requests" ADD CONSTRAINT "request_id" UNIQUE ("request_id")
;

ALTER TABLE "requests" ADD CONSTRAINT "request_name" UNIQUE ("request_name")
;

-- Table request_composition

CREATE TABLE "request_composition"
(
  "request_id" Integer NOT NULL,
  "purchased_product_id" Integer NOT NULL,
  "purchased_product_amount" Integer DEFAULT 0 NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "request_composition" ADD CONSTRAINT "PK_request_composition" PRIMARY KEY ("purchased_product_id","request_id")
;

-- Table tags

CREATE TABLE "tags"
(
  "tag_id" Integer NOT NULL GENERATED ALWAYS AS IDENTITY
    (INCREMENT BY 1 NO MINVALUE NO MAXVALUE START WITH 1 CACHE 1),
  "tag_name" Character varying(20) NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "tags" ADD CONSTRAINT "PK_tags" PRIMARY KEY ("tag_id")
;

ALTER TABLE "tags" ADD CONSTRAINT "tag_id" UNIQUE ("tag_id")
;

ALTER TABLE "tags" ADD CONSTRAINT "tag_name" UNIQUE ("tag_name")
;

-- Table product_tags

CREATE TABLE "product_tags"
(
  "product_id" Integer NOT NULL,
  "tag_id" Integer NOT NULL
)
WITH (
  autovacuum_enabled=true)
;

ALTER TABLE "product_tags" ADD CONSTRAINT "PK_product_tags" PRIMARY KEY ("tag_id","product_id")
;

-- Create foreign keys (relationships) section -------------------------------------------------

ALTER TABLE "themes"
  ADD CONSTRAINT "theme_creator"
    FOREIGN KEY ("theme_created_by")
    REFERENCES "users" ("user_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "themes"
  ADD CONSTRAINT "theme_deleter"
    FOREIGN KEY ("theme_deleted_by")
    REFERENCES "users" ("user_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "products"
  ADD CONSTRAINT "product_creator"
    FOREIGN KEY ("product_created_by")
    REFERENCES "users" ("user_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "products"
  ADD CONSTRAINT "product_deleter"
    FOREIGN KEY ("product_deleted_by")
    REFERENCES "users" ("user_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "theme_composition"
  ADD CONSTRAINT "product_included_in_themes"
    FOREIGN KEY ("product_id")
    REFERENCES "products" ("product_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "theme_composition"
  ADD CONSTRAINT "theme_consist_of_products"
    FOREIGN KEY ("theme_id")
    REFERENCES "themes" ("theme_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "purchased_products"
  ADD CONSTRAINT "purchased_product_creator"
    FOREIGN KEY ("purchased_product_created_by")
    REFERENCES "users" ("user_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "purchased_products"
  ADD CONSTRAINT "purchased_product_deleter"
    FOREIGN KEY ("purchased_product_deleted_by")
    REFERENCES "users" ("user_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "product_composition"
  ADD CONSTRAINT "purchased_products_included_in_products"
    FOREIGN KEY ("purchased_product_id")
    REFERENCES "purchased_products" ("purchased_product_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "product_composition"
  ADD CONSTRAINT "product_consist_of_purchased_products"
    FOREIGN KEY ("product_id")
    REFERENCES "products" ("product_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "requests"
  ADD CONSTRAINT "request_author"
    FOREIGN KEY ("request_created_by")
    REFERENCES "users" ("user_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "request_composition"
  ADD CONSTRAINT "purchased_products_included_in_request"
    FOREIGN KEY ("purchased_product_id")
    REFERENCES "purchased_products" ("purchased_product_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "request_composition"
  ADD CONSTRAINT "request_consist_of_purchased_products"
    FOREIGN KEY ("request_id")
    REFERENCES "requests" ("request_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "product_tags"
  ADD CONSTRAINT "tag_refers_to_products"
    FOREIGN KEY ("tag_id")
    REFERENCES "tags" ("tag_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;

ALTER TABLE "product_tags"
  ADD CONSTRAINT "product_has_tags"
    FOREIGN KEY ("product_id")
    REFERENCES "products" ("product_id")
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
;
