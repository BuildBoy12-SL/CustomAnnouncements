# Custom Announcements
- Requires [EXILED](https://github.com/galaxy119/EXILED/).
- All C.A.S.S.I.E. acceptable words can be found [here](https://pastebin.com/rpMuRYNn).

## Configs
- Leave an announcement blank if you do not want it to run.

| Config Option | Value Type | Default Value | Description |
|:------------------------:|:----------:|:-------------:|:------------------------------------------:|
| `ca_enable` | bool | true | Enables/disabled the plugin. |
| `ca_chaos_spawn` | string |  | Announcement that will be played when Chaos spawns. |
| `ca_chaos_noise` | bool | false | If CASSIE should make the default noises when Chaos spawns. |
| `ca_mtf_spawn` | string |  | Announcement that will be played when MTF spawns. |
| `ca_mtf_noise` | bool | false | If CASSIE should make the default noises when MTF spawns. |
| `ca_roundstart` | string |  | Announcement that will be played when the round starts. |
| `ca_roundstart_noise` | bool | false | If CASSIE should make the default noises when the round starts. |
| `ca_roundend` | string |  | Announcement that will be played when the round ends. |
| `ca_roundend_noise` | bool | false | If CASSIE should make the default noises when the round ends. |
| `ca_dclass_escape` | string |  | Announcement that will be played when a ClassD escapes. |
| `ca_dclass_escape_noise` | bool | false | If CASSIE should make the default noises when a ClassD escapes. |
| `ca_science_escape` | string |  | Announcement that will be played when a Scientist escapes. |
| `ca_science_escape_noise` | bool | false | If CASSIE should make the default noises when a Scientist escapes. |
| `ca_join` | dict |  | People and their corresponding announcement. |
| `ca_join_noise` | bool | false | If CASSIE should make the default noises when a player join is announced. |

- __Variables for 'ca_mtf_spawn' for current spawn info: %NtfLetter%, %NtfNumber%, %ScpsLeft%__
- __Usage for ca_join: PlayerID@steam:announcement, PlayerID@discord:announcement__

## Commands
### Note you can use v/p instead of view/play
#### Requires permission `ca_main` in EXILED_Permissions
- ca: Displays commands and info

- chs (view/play): Plays configured chaos announcement

- re (view/play): Plays configured round end announcement

- rs (view/play): Plays configured round start announcement

- de (view/play): Plays configured DClass escape announcement

- se (view/play): Plays configured Scientist escape announcement

- mtfa (scps left) (mtf number) (mtf letter): Plays mtf annoucement

- scpa (scp number) (death type): Plays scp death announcement
    - Use tesla, dclass, science, mtf, or chaos for `death type`
    - You can also use t, d, s, m, or c respectively
