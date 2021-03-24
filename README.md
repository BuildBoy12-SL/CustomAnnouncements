# Custom Announcements
- Requires [EXILED](https://github.com/galaxy119/EXILED/).
- All C.A.S.S.I.E. acceptable words can be found [here](https://steamcommunity.com/sharedfiles/filedetails/?id=1577299753).

## Configs
- Leave an announcements 'Message' blank if you do not want it to run.
- An announcement being glitchy will cause IsNoisy to not be accounted for. For now, if IsGlitchy is true, IsNoisy will also be true.
- Variables in every announcement contains the following:

| Config Option | Value Type | Description |
|:------------------------:|:----------:|:------------------------------------------:|
| `message` | string | Message that CASSIE will announce. |
| `is_noisy` | bool | If there should be background static and the starting/stopping noise. |
| `is_glitchy` | bool | If there should be glitches and jams randomly in the broadcast. |
| `glitch_chance` | float | Chance that a glitch can occur. |
| `jam_chance` | float | Chance that a jam can occur. |


Solely for PlayerJoined, the event will play when a user joins with an id contained in this list:
| Config Option | Value Type | Description |
|:------------------------:|:----------:|:------------------------------------------:|
| `user_ids` | List\<string\> | Announcement that will be played when the round starts. |


- Variables that work for all broadcasts include:

| Variable | Description |
|:------------------------:|:--------------------------------------:|
| `$ScpsLeft` | The number of alive Scps |
| `$MtfLeft` | The number of alive Mtf |
| `$SciLeft` | The number of alive scientists |
| `$CdpLeft` | The number of alive ClassD |
| `$ChiLeft` | The number of alive Chaos Insurgents |
| `$HumansLeft` | The number of alive players that are not spectators, tutorials, or Scps |
| `$TotalPlayers` | The number of players connected to the server |
| `$ScpSubjects` | Returns as 'ScpSubject' if there is only one alive Scp, otherwise returns as 'ScpSubjects' |
| `$NtfScpSubjects` | Returns the respective cassie pattern depending on how many Scps are alive (Ex. Returns as NOSCPSLEFT if there are no alive Scps) |

- Variables exclusively for the `MtfSpawn` broadcast under the Message variable include:

| Variable | Description |
|:------------------------:|:--------------------------------------:|
| `$UnitName` | The nato representation of the mtf squad. (Ex. Bravo-9 will return nato_b) |
| `$UnitNumber` | The number of the spawned unit. (Ex. Bravo-9 will return 9) |

## Commands
### Note you can use v/p instead of view/play
#### Each command requires the permission `ca.{command}`. Example: `ca.chs`
- ca: Displays commands and info

- chs (view/play): Plays configured ChaosSpawn announcement

- ed (view/play): Plays configured DClass escape announcement

- es (view/play): Plays configured Scientist escape announcement

- ms (view/play): Plays configured MTF spawn announcement

- pj (view/play): Plays configured PlayerJoined announcement

- re (view/play): Plays configured RoundEnd announcement

- rs (view/play): Plays configured RoundStart announcement

- st (view/play): Plays configured ScpTermination announcement

- fscp (mtf letter) (mtf number) (scps left): Plays mtf annoucement

- fmtf (scp number) (death type): Plays scp death announcement
    - Use tesla, dclass, science, mtf, chaos, or decont for `death type`
    - You can also use t, d, s, m, c, or decont respectively
