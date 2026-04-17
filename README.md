## Intro

A small app to merge rom dats into a single .dat. It was developed for an unusual use-case of using RomM which requires a flat roms structure with RomVault. The No-Intro set for Atari Lynx has unique entries across the Lyx and Lnx sets, so needed to merge both.

Essentially, this either merges duplicate Game elements with Tags added to the game.name and/or game.description OR picks a priority entry to place intot he final merged Dat. 

## Screenshot
<img width="1186" height="654" alt="Screenshot 2026-04-17 110219" src="https://github.com/user-attachments/assets/e49fe976-211c-4334-8947-40b44fb24cad" />

## Example Merged .DAT
```xml
<?xml version="1.0" encoding="utf-8"?>
<datafile xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="https://datomatic.no-intro.org/stuff https://datomatic.no-intro.org/stuff/schema_nointro_datfile_v3.xsd">
  <header>
    <name>Atari Lynx Merged Dat</name>
    <description>Atari - Atari Lynx (LNX-LYX-BLL) (20251222-090626)</description>
    <date>20260417-110242</date>
    <author>stigzler</author>
    <category>Merged-DAT</category>
  </header>
  <game name="2048 (World) (Aftermarket) (Unl) (BLL)" id="0382">
    <category>Games</category>
    <description>2048 (World) (Aftermarket) (Unl)</description>
    <rom name="2048 (World) (Aftermarket) (Unl).bll" size="39209" crc="2f5c3e31" md5="6d9a6d82dfea445b09065ebd33b9c679" sha1="a40ecdc1e2ed9585ba7d582b960ac3c7f96cdf08" sha256="60099434db16f4d22182099662c8dc4e3f6c8c4af7bdd1e079e91bbd0a2b1bc9" />
  </game>
  <game name="2048 (World) (Aftermarket) (Unl) (LNX)" id="0382">
    <category>Games</category>
    <description>2048 (World) (Aftermarket) (Unl)</description>
    <rom name="2048 (World) (Aftermarket) (Unl).lnx" size="262208" crc="e55a9ed0" md5="7e746002f02bbbf7edde1f20b98f1f90" sha1="a6bea51787bf14f7399cb5e1d2e3389d28fdc292" sha256="75740a4dba67d3c1a62f10f76f0a15a24f19cc2b65503a77a188ff341c45a81f" />
  </game>
  <game name="2048 (World) (Aftermarket) (Unl) (LYX)" id="0382">
    <category>Games</category>
    <description>2048 (World) (Aftermarket) (Unl)</description>
    <rom name="2048 (World) (Aftermarket) (Unl).lyx" size="262144" crc="a73938f5" md5="5515e0491719ff09553b6d7d930569bc" sha1="d379b6114fefa60e0a01e0c4df2cc9ba1287bf03" sha256="b57052291e7663852ca4963df8dc398dd623e3e0dfdc9e56a5e7d953d180e509" />
  </game>
  <game name="Angry Motes (World) (Aftermarket) (Unl) (BLL)" id="0320">
    <category>Games</category>
    <description>Angry Motes (World) (Aftermarket) (Unl)</description>
    <rom name="Angry Motes (World) (Aftermarket) (Unl).bll" size="24659" crc="a6ee8f9e" md5="56f90941e34d3bc030ce57140fd4d360" sha1="3d6f6f63775004d4d7febfcf9434ccd949800857" sha256="28e29890bd7ff1f634cfda6e29d13968f55802326da55796144616e0e3ed6d51" />
  </game>
  <game name="Angry Motes (World) (Aftermarket) (Unl) (LNX)" id="0320">
    <category>Games</category>
    <description>Angry Motes (World) (Aftermarket) (Unl)</description>
    <rom name="Angry Motes (World) (Aftermarket) (Unl).lnx" size="65408" crc="7103fd0a" md5="0d24ceb671b4802420dde7021a6602f8" sha1="318d71e7e4d0fe8d820732e19fdefd2007797e20" sha256="746bc63bf4b9618fc50dd763e7cf28771ec5799b779fc11830bcc02795d88a84" />
  </game>
  <game name="Angry Motes (World) (Aftermarket) (Unl) (LYX)" id="0320">
    <category>Games</category>
    <description>Angry Motes (World) (Aftermarket) (Unl)</description>
    <rom name="Angry Motes (World) (Aftermarket) (Unl).lyx" size="262144" crc="d6220c93" md5="12ba451250e80e6faabc688c61e7a152" sha1="b79b13e5dcf5d13d1ef435a3d112ebee62bad6c8" sha256="9ca49a2d00c6ed5d9bddd60730ce241a478cb05ab8627e92bb84ed3e68c59f95" />
  </game>
</datafile>
```
