# sboxrp

A base for roleplay in s&box.

## Installing the addon

Open sbox-dev.exe. Under the "Addons" menu from the top, select "Add from disk" and add the .addon file from this repository.

## Running the addon

In the game menu next to the "All games", press the save disk icon to the right. The addon `sboxrp` should be there.

## Dedicated server

After the addon has been succesfully installed, the dedicated server can be launched with the following parameters.

```powershell
./sbox-server.exe +gamemode local.sboxrp +map facepunch.construct
```

To connect to the dedicated server, execute the command `status` in the dedicated server console.

The output should be similar to:

```powershell
12:55:26 Server   source   : console
12:55:26 Server   hostname : SBox
12:55:26 Server   spawn    : 1
12:55:26 Server   version  : 1001/1001 9317 secure  public
12:55:26 Server   steamid  : [A:1:2027615234:20369] (90159478763877378)
...
```

The number in the steamid is what is used to connect to the server, specifically `90159478763877378`.

In the console (be it sbox.exe, sbox-dev.exe), type: `connect 90159478763877378` to connect to the dedicated server.
