﻿using black_friday.Game.Services;
using black_friday.Game.Scripting;
using black_friday.Game.Directing;
using black_friday.Game.Casting;

namespace black_friday{
    public class Program{
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args){
            
            
            //CREATE THE SERVICES
            //Create the VIDEO service
            KeyboardService keyboardService = new KeyboardService();
            //Create the KEYBOARD service
            VideoService videoService = new VideoService(false);
            //Create the MOUSE service
            MouseService mouseService = new MouseService();

            AudioService audioService = new AudioService();
            audioService.LoadSounds("Game/Props/Sounds");
            
            //CREATE THE HOME SCENE
            Scene homeScene = new Scene();
            //Create the cast for the HOME scene
            Cast homeCast = new Cast();
            //Create the home background actor
            Actor homeBackground = new Actor();
            homeBackground.SetWidth(1350);
            homeBackground.SetHeight(900);
            homeBackground.SetPath("Game/Props/store_exterior.png");
                homeBackground.SetPath("Game/Props/store_exterior_pixel.png"); //comment out for a non-pixel version
            homeBackground.SetFontSize(50);
            homeBackground.SetPosition(new Point (0,0));
            //Create the home title actor
            Actor homeTitle = new Actor();
            homeTitle.SetColor(Constants.BANNER_GREY);
            Point homeTitleStartingPoint = new Point(Constants.MAX_X / 2 - 250, 0 + 5);
            homeTitle.SetPosition(homeTitleStartingPoint);
            homeTitle.SetText("Black Friday!");
            homeTitle.SetTextColor(Constants.WHITE);
            homeTitle.SetWidth(500);
            homeTitle.SetHeight(50);
            homeTitle.SetFontSize(50);
            //Create the _settingsButton_ actor
            Button settingsButton = new Button();
            settingsButton.SetColor(Constants.BANNER_BLUE);
            Point settingsButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 105);
            settingsButton.SetPosition(settingsButtonStartingPoint);
            settingsButton.SetText("Settings");
            settingsButton.SetTextColor(Constants.WHITE);
            settingsButton.SetWidth(500);
            settingsButton.SetHeight(50);
            settingsButton.SetFontSize(50);
            //Create the _battleRoyaleButton_ actor
            Button battleRoyaleButton = new Button();
            battleRoyaleButton.SetColor(Constants.BANNER_GREEN);
            Point battleRoyaleButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 205);
            battleRoyaleButton.SetPosition(battleRoyaleButtonStartingPoint);
            battleRoyaleButton.SetText("Battle Royale");
            battleRoyaleButton.SetTextColor(Constants.WHITE);
            battleRoyaleButton.SetWidth(500);
            battleRoyaleButton.SetHeight(50);
            battleRoyaleButton.SetFontSize(50);
            //Create the shoplifterButton actor
            Button shoplifterButton = new Button();
            shoplifterButton.SetColor(Constants.BANNER_GREEN);
            Point shoplifterButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 305);
            shoplifterButton.SetPosition(shoplifterButtonStartingPoint);
            shoplifterButton.SetText("Shoplifter");
            shoplifterButton.SetTextColor(Constants.WHITE);
            shoplifterButton.SetWidth(500);
            shoplifterButton.SetHeight(50);
            shoplifterButton.SetFontSize(50);
            //Create the teamBattleButton actor
            Button teamBattleButton = new Button();
            teamBattleButton.SetColor(Constants.BANNER_GREEN);
            Point teamBattleButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 405);
            teamBattleButton.SetPosition(teamBattleButtonStartingPoint);
            teamBattleButton.SetText("Team Battle");
            teamBattleButton.SetTextColor(Constants.WHITE);
            teamBattleButton.SetWidth(500);
            teamBattleButton.SetHeight(50);
            teamBattleButton.SetFontSize(50);
            //Add actor(s) to the cast for the HOME scene
            homeCast.AddActor("background", homeBackground);
            homeCast.AddActor("info", homeTitle);
            homeCast.AddActor("button", battleRoyaleButton);
            homeCast.AddActor("button", settingsButton);
            homeCast.AddActor("button", shoplifterButton);
            homeCast.AddActor("button", teamBattleButton);
            //Create the script for the HOME scene
            Script homeScript = new Script();
            //Add INPUT action(s) to the script for the HOME scene
                homeScript.AddAction("input", new ClickButtonsAction(mouseService, audioService));
            //Add UPDATE action(s) to the script for the HOME scene
            homeScript.AddAction("update", new SettingsButtonAction());
            homeScript.AddAction("update", new BattleRoyaleButtonAction());
            homeScript.AddAction("update", new ShoplifterButtonAction());
            homeScript.AddAction("update", new TeamBattleButtonAction());
            //Add OUTPUT action(s) to the script for the HOME scene
            homeScript.AddAction("output", new DrawActorsAction(videoService));
            //Add the cast and script to the HOME scene
            homeScene.SetCast(homeCast);
            homeScene.SetScript(homeScript);



            //CREATE THE SETTINGS SCENE
            Scene settingsScene = new Scene();
            //Create the cast for the SETTINGS scene
            Cast settingsCast = new Cast();
            //Create the settingsTitle actor
            Actor settingsTitle = new Actor();
            settingsTitle.SetColor(Constants.BANNER_GREY);
            Point settingsTitleStartingPoint = new Point(Constants.MAX_X / 2 - 250, 0 + 5);
            settingsTitle.SetPosition(settingsTitleStartingPoint);
            settingsTitle.SetText("Settings");
            settingsTitle.SetTextColor(Constants.WHITE);
            settingsTitle.SetWidth(500);
            settingsTitle.SetHeight(50);
            settingsTitle.SetFontSize(50);
            //Create the homeButton actor
            Button homeButton = new Button();
            homeButton.SetColor(Constants.BANNER_RED);
            Point homeButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 105);
            homeButton.SetPosition(homeButtonStartingPoint);
            homeButton.SetText("Home");
            homeButton.SetTextColor(Constants.WHITE);
            homeButton.SetWidth(500);
            homeButton.SetHeight(50);
            homeButton.SetFontSize(50);
            //Create the npcCountButton actor
            Button npcCountButton = new Button();
            npcCountButton.SetColor(Constants.BANNER_BLUE);
            Point npcCountButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 205);
            npcCountButton.SetPosition(npcCountButtonStartingPoint);
            npcCountButton.SetText($"NPC Count: {Constants.NPC_COUNT}");
            npcCountButton.SetTextColor(Constants.WHITE);
            npcCountButton.SetWidth(570);
            npcCountButton.SetHeight(50);
            npcCountButton.SetFontSize(50);
            //Create the timerCountButton actor
            Button timerCountButton = new Button();
            timerCountButton.SetColor(Constants.BANNER_BLUE);
            Point timerCountButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 305);
            timerCountButton.SetPosition(timerCountButtonStartingPoint);
            timerCountButton.SetText($"Timer Count: {Constants.TIMER_COUNT}");
            timerCountButton.SetTextColor(Constants.WHITE);
            timerCountButton.SetWidth(570);
            timerCountButton.SetHeight(50);
            timerCountButton.SetFontSize(50);
            //Create the shopperFaceButton actor
            Button shopperFaceButton = new Button();
            shopperFaceButton.SetColor(Constants.BANNER_BLUE);
            Point shopperFaceButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 405);
            shopperFaceButton.SetPosition(shopperFaceButtonStartingPoint);
            shopperFaceButton.SetText($"Shopper Face: {Constants.SHOPPER_FACE}");
            shopperFaceButton.SetTextColor(Constants.WHITE);
            shopperFaceButton.SetWidth(570);
            shopperFaceButton.SetHeight(50);
            shopperFaceButton.SetFontSize(50);
            //Create the shopperSpeedButton actor
            Button shopperSpeedButton = new Button();
            shopperSpeedButton.SetColor(Constants.BANNER_BLUE);
            Point shopperSpeedButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 505);
            shopperSpeedButton.SetPosition(shopperSpeedButtonStartingPoint);
            shopperSpeedButton.SetText($"Shopper Speed: {Constants.SHOPPER_SPEED}");
            shopperSpeedButton.SetTextColor(Constants.WHITE);
            shopperSpeedButton.SetWidth(570);
            shopperSpeedButton.SetHeight(50);
            shopperSpeedButton.SetFontSize(50);
            //Create the extraAmmoButton actor
            Button extraAmmoButton = new Button();
            extraAmmoButton.SetColor(Constants.BANNER_BLUE);
            Point extraAmmoButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 605);
            extraAmmoButton.SetPosition(extraAmmoButtonStartingPoint);
            extraAmmoButton.SetText($"Extra Ammo Count: {Constants.EXTRA_AMMO}");
            extraAmmoButton.SetTextColor(Constants.WHITE);
            extraAmmoButton.SetWidth(570);
            extraAmmoButton.SetHeight(50);
            extraAmmoButton.SetFontSize(50);
            //Create the copCanReloadButton actor
            Button copCanReloadButton = new Button();
            copCanReloadButton.SetColor(Constants.BANNER_BLUE);
            Point copCanReloadButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 705);
            copCanReloadButton.SetPosition(copCanReloadButtonStartingPoint);
            copCanReloadButton.SetText($"Cop Can Reload: {Constants.COP_CAN_RELOAD}");
            copCanReloadButton.SetTextColor(Constants.WHITE);
            copCanReloadButton.SetWidth(570);
            copCanReloadButton.SetHeight(50);
            copCanReloadButton.SetFontSize(50);
            //Add actor(s) to the cast for the SETTINGS scene
            settingsCast.AddActor("background", homeBackground);
            settingsCast.AddActor("info", settingsTitle);
            settingsCast.AddActor("button", homeButton);
            settingsCast.AddActor("button", npcCountButton);
            settingsCast.AddActor("button", timerCountButton);
            settingsCast.AddActor("button", shopperFaceButton);
            settingsCast.AddActor("button", shopperSpeedButton);
            settingsCast.AddActor("button", extraAmmoButton);
            settingsCast.AddActor("button", copCanReloadButton);
            //Create the script for the SETTINGS scene
            Script settingsScript = new Script();
            //Add INPUT action(s) to the script for the SETTINGS scene
            settingsScript.AddAction("input", new ClickButtonsAction(mouseService, audioService));
            //Add UPDATE action(s) to the script for the SETTINGS scene
            settingsScript.AddAction("update", new HomeButtonAction());
            settingsScript.AddAction("update", new NPCCountButtonAction());
            settingsScript.AddAction("update", new TimerCountButtonAction());
            settingsScript.AddAction("update", new ShopperFaceButtonAction());
            settingsScript.AddAction("update", new ShopperSpeedButtonAction());
            settingsScript.AddAction("update", new CopCanReloadButtonAction());
            settingsScript.AddAction("update", new ExtraAmmoButtonAction());
            //Add OUTPUT action(s) to the script for the SETTINGS scene
            settingsScript.AddAction("output", new DrawActorsAction(videoService));
            //Add the cast and script to the SETTINGS scene
            settingsScene.SetCast(settingsCast);
            settingsScene.SetScript(settingsScript);



            //CREATE THE RULES SCENE
            Scene rulesScene = new Scene();
            //Create the cast for the RULES scene
            Cast rulesCast = new Cast();
            //Create the _rulesTitle_ actor
            Actor rulesTitle = new Actor();
            settingsTitle.SetColor(Constants.BANNER_GREY);
            Point rulesTitleStartingPoint = new Point(Constants.MAX_X / 2 - 250, 0 + 5);
            rulesTitle.SetPosition(rulesTitleStartingPoint);
            rulesTitle.SetText("Rules");
            rulesTitle.SetTextColor(Constants.WHITE);
            rulesTitle.SetWidth(500);
            rulesTitle.SetHeight(50);
            rulesTitle.SetFontSize(50);
            //Create the _rulesInfo_ actor
            Actor rulesInfo = new Actor();
            settingsTitle.SetColor(Constants.BANNER_GREY);
            Point rulesInfoStartingPoint = new Point(Constants.MAX_X / 2 - 530, 0 + 105);
            rulesInfo.SetPosition(rulesInfoStartingPoint);
            rulesInfo.SetText("Rules Info");
            rulesInfo.SetTextColor(Constants.WHITE);
            rulesInfo.SetWidth(1060);
            rulesInfo.SetHeight(662);
            rulesInfo.SetFontSize(35);
            //Create the _playerSelectButton_ actor
            Button playerSelectButton = new Button();
           playerSelectButton.SetColor(Constants.BANNER_GREEN);
            Point playerSelectButtonStartingPoint = new Point(Constants.MAX_X / 2 - 600, 0 + 800);
            playerSelectButton.SetPosition(playerSelectButtonStartingPoint);
            playerSelectButton.SetText("To Player Select");
            playerSelectButton.SetTextColor(Constants.WHITE);
            playerSelectButton.SetWidth(500);
            playerSelectButton.SetHeight(50);
            playerSelectButton.SetFontSize(50);
            //Create the _homeButton_ actor
            Button ruleshomeButton = new Button();
            ruleshomeButton.SetColor(Constants.BANNER_RED);
            Point ruleshomeButtonStartingPoint = new Point(Constants.MAX_X / 2, 0 + 800);
            ruleshomeButton.SetPosition(ruleshomeButtonStartingPoint);
            ruleshomeButton.SetText("Home");
            ruleshomeButton.SetTextColor(Constants.WHITE);
            ruleshomeButton.SetWidth(500);
            ruleshomeButton.SetHeight(50);
            ruleshomeButton.SetFontSize(50);
            //Add actor(s) to the cast for the RULES scene
            rulesCast.AddActor("background", homeBackground);
            rulesCast.AddActor("info", rulesTitle);
            rulesCast.AddActor("info", rulesInfo);
            rulesCast.AddActor("button", playerSelectButton);
            rulesCast.AddActor("button", ruleshomeButton);
            //Create the script for the RULES scene
            Script rulesScript = new Script();
            //Add INPUT action(s) to the script for the RULES scene
            rulesScript.AddAction("input", new ClickButtonsAction(mouseService, audioService));
            //Add UPDATE action(s) to the script for the RULES scene
            rulesScript.AddAction("update", new PlayerSelectButtonAction());
            rulesScript.AddAction("update", new HomeButtonAction());
            rulesScript.AddAction("update", new SetRulesInfoAction(audioService));
            //Add OUTPUT action(s) to the script for the RULES scene
            rulesScript.AddAction("output", new DrawActorsAction(videoService));
            rulesScript.AddAction("output", new PlaySoundAction(audioService));            
            //Add the cast and script to the RULES scene
            rulesScene.SetCast(rulesCast);
            rulesScene.SetScript(rulesScript);



            //CREATE THE PLAYER SELECT SCENE
            Scene playerSelectScene = new Scene();
            //Create the cast for the PLAYER SELECT scene
            Cast playerSelectCast = new Cast();
            //Create the _playerSelectTitle_ actor
            Actor playerSelectTitle = new Actor();
            playerSelectTitle.SetColor(Constants.BANNER_GREY);
            Point playerSelectTitleStartingPoint = new Point(Constants.MAX_X / 2 - 250, 0 + 5);
            playerSelectTitle.SetPosition(playerSelectTitleStartingPoint);
            playerSelectTitle.SetText("Player Select");
            playerSelectTitle.SetTextColor(Constants.WHITE);
            playerSelectTitle.SetWidth(500);
            playerSelectTitle.SetHeight(50);
            playerSelectTitle.SetFontSize(50);
            //Create the playerSelectInfo actor
            Actor playerSelectInfo = new Actor();
            playerSelectInfo.SetColor(Constants.BANNER_GREY);
            Point playerSelectInfoStartingPoint = new Point(Constants.MAX_X / 2 - 530, 0 + 105);
            playerSelectInfo.SetPosition(playerSelectInfoStartingPoint);
            playerSelectInfo.SetText("Player Select Info");
            playerSelectInfo.SetTextColor(Constants.WHITE);
            playerSelectInfo.SetWidth(1060);
            playerSelectInfo.SetHeight(662);
            playerSelectInfo.SetFontSize(30);
            //Create the _playerNumberButton_ actor
            Button playerNumberButton = new Button();
            playerNumberButton.SetColor(Constants.BANNER_BLUE);
            Point playerNumberButtonStartingPoint = new Point(Constants.MAX_X / 2 - 600, 0 + 800);
            playerNumberButton.SetPosition(playerNumberButtonStartingPoint);
            playerNumberButton.SetText($"Number of Players: {Constants.PLAYER_COUNT}");
            playerNumberButton.SetTextColor(Constants.WHITE);
            playerNumberButton.SetWidth(550);
            playerNumberButton.SetHeight(50);
            playerNumberButton.SetFontSize(50);

            //Create the _playButton_ actor
            Button playButton = new Button();
            playButton.SetColor(Constants.BANNER_GREEN);
            Point playButtonStartingPoint = new Point(Constants.MAX_X / 2, 0 + 800);
            playButton.SetPosition(playButtonStartingPoint);
            playButton.SetText("Start Game");
            playButton.SetTextColor(Constants.WHITE);
            playButton.SetWidth(300);
            playButton.SetHeight(50);
            playButton.SetFontSize(50);

            //Create the playerSelectHomeButton actor
            Button playerSelectHomeButton = new Button();
            playerSelectHomeButton.SetColor(Constants.BANNER_RED);
            Point playerSelectHomeButtonStartingPoint = new Point(Constants.MAX_X / 2 + 350, 0 + 800);
            playerSelectHomeButton.SetPosition(playerSelectHomeButtonStartingPoint);
            playerSelectHomeButton.SetText("Home");
            playerSelectHomeButton.SetTextColor(Constants.WHITE);
            playerSelectHomeButton.SetWidth(125);
            playerSelectHomeButton.SetHeight(50);
            playerSelectHomeButton.SetFontSize(50);
            
            //Add actor(s) to the cast for the PLAYER SELECT scene
            playerSelectCast.AddActor("background", homeBackground);
            playerSelectCast.AddActor("info", playerSelectTitle);
            playerSelectCast.AddActor("info", playerSelectInfo);
            playerSelectCast.AddActor("button", playerNumberButton);
            playerSelectCast.AddActor("button", playButton);
            playerSelectCast.AddActor("button", playerSelectHomeButton);
            
            //Create the script for the PLAYER SELECT scene
            Script playerSelectScript = new Script();
            //Add INPUT action(s) to the script for the PLAYER SELECT scene
            playerSelectScript.AddAction("input", new ClickButtonsAction(mouseService, audioService));
            //Add UPDATE action(s) to the script for the PLAYER SELECT scene
            playerSelectScript.AddAction("update", new HomeButtonAction());
            playerSelectScript.AddAction("update", new PlayerNumberButtonAction());
            playerSelectScript.AddAction("update", new PlayButtonAction());
            playerSelectScript.AddAction("update", new SetPlayerSelectInfoAction());
            
            //Add OUTPUT action(s) to the script for the PLAYER SELECT scene
            playerSelectScript.AddAction("output", new DrawActorsAction(videoService));
            //Add the cast and script to the PLAYER SELECT scene
            playerSelectScene.SetCast(playerSelectCast);
            playerSelectScene.SetScript(playerSelectScript);



            //CREATE THE BATTLE ROYALE SCENE
            Scene battleRoyaleScene = new Scene();
            battleRoyaleScene.SetIsGameScene(true);
            //Create the script for the BATTLE ROYALE scene
            Script battleRoyaleScript = new Script();
            //Add START action(s) to the script for the BATTLE ROYALE scene (will only execute once (before the scene's loop starts))
            battleRoyaleScript.AddAction("start", new InstantiateGameActorsAction());
            //Add INPUT action(s) to the script for the BATTLE ROYALE scene
            battleRoyaleScript.AddAction("input", new ControlPlayer1Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer2Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer3Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer4Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer5Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer6Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer7Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer8Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer9Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer10Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer11Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer12Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer13Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer14Action());
            battleRoyaleScript.AddAction("input", new ControlPlayer15Action());
            //Add UPDATE action(s) to the script for the BATTLE ROYALE scene
            battleRoyaleScript.AddAction("update", new ManageTimerAction());
            battleRoyaleScript.AddAction("update", new DirectZombieShoppersAction());
            battleRoyaleScript.AddAction("update", new MoveActorsAction());
            battleRoyaleScript.AddAction("update", new HandlePunchCollisionAction());
            battleRoyaleScript.AddAction("update", new ReviveZombiesAction());
            battleRoyaleScript.AddAction("update", new HandleVictoryRoyale());
            //Add OUTPUT action(s) to the script for the BATTLE ROYALE scene
            battleRoyaleScript.AddAction("output", new DrawActorsAction(videoService));
            //Add the script to the BATTLE ROYALE scene
            battleRoyaleScene.SetScript(battleRoyaleScript);




            //CREATE THE SHOPLIFTER SCENE
            Scene shoplifterScene = new Scene();
            shoplifterScene.SetIsGameScene(true);
            //Create the script for the SHOPLIFTER scene
            Script shoplifterScript = new Script();
            //Add START action(s) to the script for the SHOPLIFTER scene (will only execute once (before the scene's loop starts))
            shoplifterScript.AddAction("start", new InstantiateGameActorsAction());
            shoplifterScript.AddAction("start", new InstantiateShoplifterActorsAction());
            //Add INPUT action(s) to the script for the SHOPLIFTER scene
            shoplifterScript.AddAction("input", new ControlPlayer1Action());
            shoplifterScript.AddAction("input", new ControlPlayer2Action());
            shoplifterScript.AddAction("input", new ControlPlayer3Action());
            shoplifterScript.AddAction("input", new ControlPlayer4Action());
            shoplifterScript.AddAction("input", new ControlPlayer5Action());
            shoplifterScript.AddAction("input", new ControlPlayer6Action());
            shoplifterScript.AddAction("input", new ControlPlayer7Action());
            shoplifterScript.AddAction("input", new ControlPlayer8Action());
            shoplifterScript.AddAction("input", new ControlPlayer9Action());
            shoplifterScript.AddAction("input", new ControlPlayer10Action());
            shoplifterScript.AddAction("input", new ControlPlayer11Action());
            shoplifterScript.AddAction("input", new ControlPlayer12Action());
            shoplifterScript.AddAction("input", new ControlPlayer13Action());
            shoplifterScript.AddAction("input", new ControlPlayer14Action());
            shoplifterScript.AddAction("input", new ControlPlayer15Action());
            //Add UPDATE action(s) to the script for the SHOPLIFTER scene
            shoplifterScript.AddAction("update", new ManageTimerAction());
            shoplifterScript.AddAction("update", new ManageAmmoCountAction());
            shoplifterScript.AddAction("update", new ManageScoreBannersAction());
            shoplifterScript.AddAction("update", new MallCopGunAction());
            shoplifterScript.AddAction("update", new DirectZombieShoppersAction());
            shoplifterScript.AddAction("update", new MoveActorsAction());
            shoplifterScript.AddAction("update", new MoveMallCopAction());
            shoplifterScript.AddAction("update", new HandlePunchCollisionAction());
            shoplifterScript.AddAction("update", new HandleToasterCollisionAction());
            shoplifterScript.AddAction("update", new ReviveZombiesAction());
            shoplifterScript.AddAction("update", new ReloadMallCopGunAction());
            shoplifterScript.AddAction("update", new HandleVictoryShoplifter());
            //Add OUTPUT action(s) to the script for the SHOPLIFTER scene
            shoplifterScript.AddAction("output", new DrawActorsAction(videoService));
            //Add the script to the SHOPLIFTER scene
            shoplifterScene.SetScript(shoplifterScript);




            //CREATE THE teamBattle SCENE
            Scene teamBattleScene = new Scene();
            teamBattleScene.SetIsGameScene(true);
            //Create the script for the teamBattle scene
            Script teamBattleScript = new Script();
            //Add START action(s) to the script for the teamBattle scene (will only execute once (before the scene's loop starts))
            teamBattleScript.AddAction("start", new InstantiateGameActorsAction());
            teamBattleScript.AddAction("start", new InstantiateTeamBattleActorsAction());
            //Add INPUT action(s) to the script for the teamBattle scene
            teamBattleScript.AddAction("input", new ControlPlayer1Action());
            teamBattleScript.AddAction("input", new ControlPlayer2Action());
            teamBattleScript.AddAction("input", new ControlPlayer3Action());
            teamBattleScript.AddAction("input", new ControlPlayer4Action());
            teamBattleScript.AddAction("input", new ControlPlayer5Action());
            teamBattleScript.AddAction("input", new ControlPlayer6Action());
            teamBattleScript.AddAction("input", new ControlPlayer7Action());
            teamBattleScript.AddAction("input", new ControlPlayer8Action());
            teamBattleScript.AddAction("input", new ControlPlayer9Action());
            teamBattleScript.AddAction("input", new ControlPlayer10Action());
            teamBattleScript.AddAction("input", new ControlPlayer11Action());
            teamBattleScript.AddAction("input", new ControlPlayer12Action());
            teamBattleScript.AddAction("input", new ControlPlayer13Action());
            teamBattleScript.AddAction("input", new ControlPlayer14Action());
            teamBattleScript.AddAction("input", new ControlPlayer15Action());
            //Add UPDATE action(s) to the script for the teamBattle scene
            teamBattleScript.AddAction("update", new ManageTimerAction());
            teamBattleScript.AddAction("update", new DirectZombieShoppersAction());
            teamBattleScript.AddAction("update", new MoveActorsAction());
            teamBattleScript.AddAction("update", new HandlePunchCollisionAction());
            teamBattleScript.AddAction("update", new ReviveZombiesAction());
            teamBattleScript.AddAction("update", new RevivePlayersAction());
            teamBattleScript.AddAction("update", new ManageTeamScoreBannersAction());
            //Add OUTPUT action(s) to the script for the teamBattle scene
            teamBattleScript.AddAction("output", new DrawActorsAction(videoService));
            //Add the script to the teamBattle scene
            teamBattleScene.SetScript(teamBattleScript);



            //CREATE THE GAME OVER SCENE
            Scene gameOverScene = new Scene();
            //Create the cast for the GAME OVER scene
            Cast gameOverCast = new Cast();
            //Create the _gameOverTitle_ actor
            Actor gameOverTitle = new Actor();
            gameOverTitle.SetColor(Constants.BANNER_GREY);
            Point gameOverTitleStartingPoint = new Point(Constants.MAX_X / 2 - 250, 0 + 5);
            gameOverTitle.SetPosition(gameOverTitleStartingPoint);
            gameOverTitle.SetText("Game Over");
            gameOverTitle.SetTextColor(Constants.WHITE);
            gameOverTitle.SetWidth(500);
            gameOverTitle.SetHeight(50);
            gameOverTitle.SetFontSize(50);
            //Create the _gameOverInfo_ actor
            Actor gameOverInfo = new Actor();
            gameOverInfo.SetColor(Constants.BANNER_GREY);
            Point gameOverInfoStartingPoint = new Point(Constants.MAX_X / 2 - 350, 0 + 105);
            gameOverInfo.SetPosition(gameOverInfoStartingPoint);
            gameOverInfo.SetText("");
            gameOverInfo.SetTextColor(Constants.WHITE);
            gameOverInfo.SetWidth(700);
            gameOverInfo.SetHeight(100);
            gameOverInfo.SetFontSize(52);
            //Create the _quickRestartButton_ actor
            Button quickRestartButton = new Button();
            quickRestartButton.SetColor(Constants.BANNER_BLUE);
            Point quickRestartButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 255);
            quickRestartButton.SetPosition(quickRestartButtonStartingPoint);
            quickRestartButton.SetText("Quick Restart");
            quickRestartButton.SetTextColor(Constants.WHITE);
            quickRestartButton.SetWidth(500);
            quickRestartButton.SetHeight(50);
            quickRestartButton.SetFontSize(50);
            //Create the _homeButton_ actor
            Button gameOverHomeButton = new Button();
            gameOverHomeButton.SetColor(Constants.BANNER_RED);
            Point gameOverHomeButtonStartingPoint = new Point(Constants.MAX_X / 2 - 400, 0 + 355);
            gameOverHomeButton.SetPosition(gameOverHomeButtonStartingPoint);
            gameOverHomeButton.SetText("Home");
            gameOverHomeButton.SetTextColor(Constants.WHITE);
            gameOverHomeButton.SetWidth(500);
            gameOverHomeButton.SetHeight(50);
            gameOverHomeButton.SetFontSize(50);
            //Add actor(s) to the cast for the GAME OVER scene
            gameOverCast.AddActor("background", homeBackground);
            gameOverCast.AddActor("info", gameOverTitle);
            gameOverCast.AddActor("info", gameOverInfo);
            gameOverCast.AddActor("button", gameOverHomeButton);
            gameOverCast.AddActor("button", quickRestartButton);
            //Create the script for the GAME OVER scene
            Script gameOverScript = new Script();
            //Add INPUT action(s) to the script for the GAME OVER scene
            gameOverScript.AddAction("input", new ClickButtonsAction(mouseService, audioService));
            //Add UPDATE action(s) to the script for the GAME OVER scene
            gameOverScript.AddAction("update", new HomeButtonAction());
            gameOverScript.AddAction("update", new QuickRestartButtonAction());
            gameOverScript.AddAction("update", new SetGameOverInfoAction());
            //Add OUTPUT action(s) to the script for the GAME OVER scene
            gameOverScript.AddAction("output", new DrawActorsAction(videoService));
            //Add the cast and script to the GAME OVER scene
            gameOverScene.SetCast(gameOverCast);
            gameOverScene.SetScript(gameOverScript);

            



            //CREATE THE DIRECTING
            //Create the DIRECTOR
            Director director = new Director(videoService);
            //Create the NEXT SCENE INFO
            NextSceneInfo nextSceneInfo = new NextSceneInfo();
            //Set to start at the HOME SCENE
            nextSceneInfo.SetNextSceneName("home");
            //Declare a method for converting the string scene name to the proper instance of Scene.
            Scene ConvertSceneNameToInstance(string sceneName){
            switch (sceneName){
                case "home":
                    return homeScene;
                case "settings":
                    return settingsScene;
                case "rules":
                    return rulesScene;
                case "playerselect":
                    return playerSelectScene;
                case "battleroyale":
                    return battleRoyaleScene;
                case "gameover":
                    return gameOverScene;
                case "shoplifter":
                    return shoplifterScene;
                case "teambattle":
                    return teamBattleScene;
                default:
                    return homeScene;
            }
        }



            //BEGIN THE PROGRAM LOOP
            videoService.OpenWindow();
            while (videoService.IsWindowOpen()){
                //Play the scene that is up to be played (determined by the nextSceneName saved in Program's instance of NextSceneInfo), then assign the returned instance of NextSceneInfo to Program's instance of NextSceneInfo
                nextSceneInfo = director.PlayScene(ConvertSceneNameToInstance(nextSceneInfo.GetNextSceneName()));
                //Set the scene-to-be-executed-next's instance of NextSceneInfo to be equal to Program's (newly updated) instance of NextSceneInfo.
                //This way, a scene can communicate to the next scene.
                ConvertSceneNameToInstance(nextSceneInfo.GetNextSceneName()).SetNextSceneInfo(nextSceneInfo);
            }
            videoService.CloseWindow();
        }
    }
}
