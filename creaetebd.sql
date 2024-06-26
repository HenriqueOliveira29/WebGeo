CREATE EXTENSION IF NOT EXISTS postgis;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE EXTENSION IF NOT EXISTS postgis;

CREATE TABLE "Clients" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "Address" text NOT NULL,
    CONSTRAINT "PK_Clients" PRIMARY KEY ("Id")
);

CREATE TABLE "Products" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "Preco" real NOT NULL,
    CONSTRAINT "PK_Products" PRIMARY KEY ("Id")
);

CREATE TABLE "Shops" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Location" geometry(Point, 4326) NOT NULL,
    CONSTRAINT "PK_Shops" PRIMARY KEY ("Id")
);

CREATE TABLE "Storages" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Location" geometry(Point, 4326) NOT NULL,
    CONSTRAINT "PK_Storages" PRIMARY KEY ("Id")
);

CREATE TABLE "Orders" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Date" timestamp with time zone NOT NULL,
    "State" text NOT NULL,
    "DateDeliver" timestamp with time zone,
    "ClientId" integer NOT NULL,
    "ShopId" integer NOT NULL,
    CONSTRAINT "PK_Orders" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Orders_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "Clients" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Orders_Shops_ShopId" FOREIGN KEY ("ShopId") REFERENCES "Shops" ("Id") ON DELETE CASCADE
);

CREATE TABLE "ProductShops" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "ProductId" integer NOT NULL,
    "ShopId" integer NOT NULL,
    "Stock" real NOT NULL,
    CONSTRAINT "PK_ProductShops" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ProductShops_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_ProductShops_Shops_ShopId" FOREIGN KEY ("ShopId") REFERENCES "Shops" ("Id") ON DELETE CASCADE
);

CREATE TABLE "ProductStorages" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "ProductId" integer NOT NULL,
    "StorageId" integer NOT NULL,
    "Stock" real NOT NULL,
    CONSTRAINT "PK_ProductStorages" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ProductStorages_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_ProductStorages_Storages_StorageId" FOREIGN KEY ("StorageId") REFERENCES "Storages" ("Id") ON DELETE CASCADE
);

CREATE TABLE "ProductOrders" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "OrderId" integer NOT NULL,
    "ProductId" integer NOT NULL,
    "Quantity" real NOT NULL,
    CONSTRAINT "PK_ProductOrders" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ProductOrders_Orders_OrderId" FOREIGN KEY ("OrderId") REFERENCES "Orders" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_ProductOrders_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Orders_ClientId" ON "Orders" ("ClientId");

CREATE INDEX "IX_Orders_ShopId" ON "Orders" ("ShopId");

CREATE INDEX "IX_ProductOrders_OrderId" ON "ProductOrders" ("OrderId");

CREATE INDEX "IX_ProductOrders_ProductId" ON "ProductOrders" ("ProductId");

CREATE INDEX "IX_ProductShops_ProductId" ON "ProductShops" ("ProductId");

CREATE INDEX "IX_ProductShops_ShopId" ON "ProductShops" ("ShopId");

CREATE INDEX "IX_ProductStorages_ProductId" ON "ProductStorages" ("ProductId");

CREATE INDEX "IX_ProductStorages_StorageId" ON "ProductStorages" ("StorageId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240430153019_init', '8.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE "ProductOrders" ADD "InShop" boolean NOT NULL DEFAULT TRUE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240510161121_AddFiledInShop', '8.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE "Storages" DROP COLUMN "Location";

ALTER TABLE "Shops" DROP COLUMN "Location";

ALTER TABLE "Storages" ADD "LocalityId" integer NOT NULL DEFAULT 0;

ALTER TABLE "Shops" ADD "LocalityId" integer NOT NULL DEFAULT 0;

CREATE TABLE "Localities" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    "Location" geometry(Point, 3763) NOT NULL,
    CONSTRAINT "PK_Localities" PRIMARY KEY ("Id")
);

CREATE TABLE "Routes" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Weight" integer NOT NULL,
    "Time" integer NOT NULL,
    "OriginId" integer NOT NULL,
    "DestinyId" integer NOT NULL,
    CONSTRAINT "PK_Routes" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Routes_Localities_DestinyId" FOREIGN KEY ("DestinyId") REFERENCES "Localities" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Routes_Localities_OriginId" FOREIGN KEY ("OriginId") REFERENCES "Localities" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Storages_LocalityId" ON "Storages" ("LocalityId");

CREATE INDEX "IX_Shops_LocalityId" ON "Shops" ("LocalityId");

CREATE INDEX "IX_Routes_DestinyId" ON "Routes" ("DestinyId");

CREATE INDEX "IX_Routes_OriginId" ON "Routes" ("OriginId");

ALTER TABLE "Shops" ADD CONSTRAINT "FK_Shops_Localities_LocalityId" FOREIGN KEY ("LocalityId") REFERENCES "Localities" ("Id") ON DELETE CASCADE;

ALTER TABLE "Storages" ADD CONSTRAINT "FK_Storages_Localities_LocalityId" FOREIGN KEY ("LocalityId") REFERENCES "Localities" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240525160007_AddLocalityAndRoutesEntities', '8.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE "Routes" ADD "Geom" geometry(LINESTRING, 3763) NOT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240527110019_addLineStringInRoutes', '8.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE "Orders" ADD "DateDeliverToClient" timestamp with time zone;

ALTER TABLE "Orders" ADD "StorageRestockId" integer;

CREATE INDEX "IX_Orders_StorageRestockId" ON "Orders" ("StorageRestockId");

ALTER TABLE "Orders" ADD CONSTRAINT "FK_Orders_Storages_StorageRestockId" FOREIGN KEY ("StorageRestockId") REFERENCES "Storages" ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240604172040_addStorageRestock', '8.0.4');

COMMIT;

