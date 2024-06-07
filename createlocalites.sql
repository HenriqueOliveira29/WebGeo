
--Localidades
INSERT INTO public."Localities" VALUES (1, 'MAIA', '0101000020B30E00002BC15419950AE4C0B2E341FB663A0541');
INSERT INTO public."Localities" VALUES (5, 'Porto', '0101000020B30E0000564ACFAFC894E3C003F4949F47190441');
INSERT INTO public."Localities" VALUES (11, 'Famalicao', '0101000020B30E00004D1862E6209DDFC0CA6FE79BD89D0741');
INSERT INTO public."Localities" VALUES (14, 'Braga', '0101000020B30E0000D65ADD00DE0FD8C02648CF77E9860941');
INSERT INTO public."Localities" VALUES (10, 'St. Tirso', '0101000020B30E00006CE01FBC6EC6DBC034DD6A25DAB00641');
INSERT INTO public."Localities" VALUES (4, 'Trofa1', '0101000020B30E000091D28242DB68E1C02668F5526A960641');
INSERT INTO public."Localities" VALUES (12, 'Barcelos', '0101000020B30E0000F69AD7C495ECE3C01D5AB651903C0941');

--Rotas
INSERT INTO public."Routes" VALUES (2, 20, 15, 5, 1, '0102000020B30E000002000000AAF1D24D62C051C0BC96900F7AB63E40AAF1D24D628052C05E4BC8073D5B4440');
INSERT INTO public."Routes" VALUES (3, 20, 15, 1, 4, '0102000020B30E000002000000AAF1D24D628052C05E4BC8073D5B4440AAF1D24D620051C05E4BC8073D5B4940');
INSERT INTO public."Routes" VALUES (4, 20, 15, 4, 10, '0102000020B30E000002000000AAF1D24D620051C05E4BC8073D5B494054E3A59BC40049C05E4BC8073DDB4B40');
INSERT INTO public."Routes" VALUES (5, 20, 15, 4, 11, '0102000020B30E000002000000AAF1D24D620051C05E4BC8073D5B4940AAF1D24D620051C05E4BC8073D5B4E40');
INSERT INTO public."Routes" VALUES (6, 20, 15, 10, 11, '0102000020B30E00000200000054E3A59BC40049C05E4BC8073DDB4B40AAF1D24D620051C05E4BC8073D5B4E40');
INSERT INTO public."Routes" VALUES (7, 20, 15, 11, 12, '0102000020B30E000002000000AAF1D24D620051C05E4BC8073D5B4E40AAF1D24D620054C0AF25E4839E6D5040');
INSERT INTO public."Routes" VALUES (8, 20, 15, 11, 14, '0102000020B30E000002000000AAF1D24D620051C05E4BC8073D5B4E4054E3A59BC40048C0AF25E4839EAD5140');

INSERT INTO public."Routes" VALUES (9, 20, 15, 1, 5, '0102000020B30E000002000000AAF1D24D628052C05E4BC8073D5B4440AAF1D24D62C051C0BC96900F7AB63E40');
INSERT INTO public."Routes" VALUES (10, 20, 15, 4, 1, '0102000020B30E000002000000AAF1D24D620051C05E4BC8073D5B4940AAF1D24D628052C05E4BC8073D5B4440');
INSERT INTO public."Routes" VALUES (11, 20, 15, 10, 4, '0102000020B30E00000200000054E3A59BC40049C05E4BC8073DDB4B40AAF1D24D620051C05E4BC8073D5B4940');
INSERT INTO public."Routes" VALUES (12, 20, 15, 11, 10, '0102000020B30E000002000000AAF1D24D620051C05E4BC8073D5B4E4054E3A59BC40049C05E4BC8073DDB4B40');
INSERT INTO public."Routes" VALUES (13, 20, 15, 12, 11, '0102000020B30E000002000000AAF1D24D620054C0AF25E4839E6D5040AAF1D24D620051C05E4BC8073D5B4E40');
INSERT INTO public."Routes" VALUES (14, 20, 15, 11, 4, '0102000020B30E000002000000AAF1D24D620051C05E4BC8073D5B4E40AAF1D24D620051C05E4BC8073D5B4940');
INSERT INTO public."Routes" VALUES (15, 20, 15, 14, 11, '0102000020B30E00000200000054E3A59BC40048C0AF25E4839EAD5140AAF1D24D620051C05E4BC8073D5B4E40');


--Shops
INSERT INTO public."Shops" VALUES (2, 1);
INSERT INTO public."Shops" VALUES (3, 4);
INSERT INTO public."Shops" VALUES (4, 5);
INSERT INTO public."Shops" VALUES (5, 10);
INSERT INTO public."Shops" VALUES (6, 11);
INSERT INTO public."Shops" VALUES (7, 12);
INSERT INTO public."Shops" VALUES (8, 14);

--Armazens
INSERT INTO public."Storages" VALUES (2, 1);
INSERT INTO public."Storages" VALUES (3, 14);

