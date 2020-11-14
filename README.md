# Custom Announcements
- Requires [EXILED](https://github.com/galaxy119/EXILED/).
- All C.A.S.S.I.E. acceptable words can be found [here](https://pastebin.com/rpMuRYNn).

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
| `user_ids` | List\<string\> | Announcement that will be played when the round starts. |


- Variables for 'ScpTermination' under the Message variable include: $TerminationCause, $TerminatorRole, $NtfUnit
	- $NtfUnit returns as "Unknown" if the killer was not an NTF
- Variables for 'NtfSpawn' under the Message variable include: $ScpsLeft, $UnitName, $UnitNumber

## Commands
### Note you can use v/p instead of view/play
#### Requires permission `ca.main` in EXILED_Permissions
- ca: Displays commands and info

- chs (view/play): Plays configured ChaosSpawn announcement

- ed (view/play): Plays configured DClass escape announcement

- es (view/play): Plays configured Scientist escape announcement

- ms (view/play): Plays configured MTF spawn announcement

- pj (view/play): Plays configured PlayerJoined announcement

- re (view/play): Plays configured RoundEnd announcement

- rs (view/play): Plays configured RoundStart announcement

- st (view/play): Plays configured ScpTermination announcement


#### Coming Soon
- mtfa (scps left) (mtf number) (mtf letter): Plays mtf annoucement

- scpa (scp number) (death type): Plays scp death announcement
    - Use tesla, dclass, science, mtf, or chaos for `death type`
    - You can also use t, d, s, m, or c respectively
