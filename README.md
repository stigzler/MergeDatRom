## Intro

A small app to merge rom dats (eg. No-Intro, Redump and TOSEC) into a single .dat. It was developed for an unusual use-case of using RomM which requires a flat roms structure alongside RomVault. The No-Intro set for Atari Lynx has unique entries across the Lyx and Lnx sets, so needed to merge both.

Essentially, this either merges duplicate Game elements with Tags added to the game.name and/or game.description OR picks a priority entry to place into the final merged Dat. 

## Screenshot
<img width="1075" height="888" alt="Screenshot 2026-04-18 132525" src="https://github.com/user-attachments/assets/09f8187f-b0fb-4d28-8c3a-40511a9bc144" />

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
# Guide

## Overview

Helps with merging rom set dats where they are in different formats. E.g No-Intro Atari Lynx are plsit into different sets (Lnx, Lyx and Bll amongst others) and sometimes in order to get a full set of games for eg, you have to pick out of each. This helps automate this process to produce a 1g1r (1 game, 1 rom) set if required or a merged dat with references to each file type. It can be used before retool if required. It also can be used with TOSEC, which re-tool can't to produce 1g1r sets.

## Operational

<img width="889" height="783" alt="Guide" src="https://github.com/user-attachments/assets/f505933e-0c62-4bf4-8959-36f9af8c9c05" />

### 1\. Import Dats

Click "Load Dats" to import dats or this is done automatically if using the "Load Setup" button. These can be ordered to influence the merge behaviour. If MDR finds roms for the same game in different dats (eg. in CAR and ATR in the pictured example) then it will choose the topmost first (if you choose KeepPriorityOnly as the merge method). 

### 2\. Dat information and individual settings

Gives information from the Dat headers. Also contains the following settings:

**Exclude Tags:** see section 4 below for full explanation. Any tags here will be added to the global tags used to exclude games/roms.

**Include Tags:** see section 4 below for full explanation. Any tags here will be added to the global tags used to include games/roms.

**Tag**: If TagAll or TagAllButPriority selected in Method (see 4) then this is the tag that will be added in the output dat. 

### 3\. Merged Dat Header Settings

This populates the header of the merged dat with the information set here. Note: you can set a 'default' via "Set Defaults" button which is how this will read at startup. Useful if you want to use a common author or Category for eg. 

### 4\. Main Merge Settings

**Method:**

**Keep priority only:**

If the setup produces a number of roms for the same game from the different Dats, this will keep the priority one determined by the Dat order in the left hand list and also form any tagging filters. 

**Tag All:**

If more than one rom for each game, will keep one from each set (eg. one form CAR and one form ATR) and prefix or suffix a tag. Eg. two entries in the merged dat:

> Witness, The (1983)(Infocom)(US)(CAR)
> 
> Witness, The (1983)(Infocom)(US)(ATR)

**Tag All but Priority:**

As per above, but doesn't tag the priority game/rom.

**Exclude Tags:**

A comma separated list of tags that is found in the game name, will be excluded form the merge results. Use for things like \[v\] in tosec (v = virus). Setting these here will apply to all dats loaded in the left hand list. If you want more specific tag exclusions for a specific set format, you can add these individually in 2. 

**Include Tags:** Like exclude tags, but indicates game/rom should be included in final merged dat. In priority order if using KeepPriorityOnly. Can also set for each individual Dat as per Exclude Tags. 

**Strip Tags for Game Grouping:** 

Games are grouped (i.e. considered as one entity) by the game name alone rather than by name and tags. Eg:

"747 Landing Simulator (1981)(APX)(US)\[a2\]\[BASIC\]"

becomes 

"747 Landing Simulator"

Note: MDR automatically accommodates date/year tags, so you don't have to worry about controlling for those tags. For eg, it will identify these two as different games despite being the same root game name:

"007 - The Living Daylights (1987)(Domark)(GB)\[k-file\] (ATR)"

"007 - The Living Daylights (1994)(ANG Software)(NL)(en)"

**Tags to filter**

Whether to do the above on bracketed tags - "( )" eg "(NL)" or on square brackets - "\[ \]" eg "\[BASIC\]"

**Preserve Multi-Disc Formats**

Tick this to include all disks/sides/parts as separate game files (needed for emulators). Eg if false, only this gets merged:

"Lucifer's Realm (1985)(All American Adventure)(GB)(Disk 1 of 2 Side A)\[OS-B\]"

However, if true, you get all 4:

"Lucifer's Realm (1985)(All American Adventure)(GB)(Disk 1 of 2 Side A)\[OS-B\]"

"Lucifer's Realm (1985)(All American Adventure)(GB)(Disk 1 of 2 Side B)\[OS-B\]"

(etc)

### 5\. Output

**Tag Position:**

Where to put the Tag in the merged dat game name, as per Method.TagAll in 4.

**Also Tag Description:** 

Also put the tag in the game's description.

Open File after cretaed:

Once file has been saved - opens a copy for you to view. Use with Notepad++ to get a live copy

### 6\. Actions

**Set Defaults**

Captures the header info and also merge settings as a default that loads on app startup. 

**Load Setup:**

You can open a MDR merged dat that you've already made and this will restore all the settings and the documents (if they are in the same file locations they were when you merged them last). The log will tell you specifically what's missing if they aren't. This is useful for iterating on settings until your merged dat is just right. 

**Merge Dats:**

Do the merge. You will choose a directory and filename of what to save the merged dat as. 

&nbsp;
