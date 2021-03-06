﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace Johnny_Punchfucker
{
    class Level3 : Level
    {
        public Level3(ContentManager Content, PlayerManager playerManager, EnemyManager enemyManager)
            : base(Content, playerManager, enemyManager)
        {
            contentLoader = new ContentLoader(Content, @"Content/Levels/lvl3environment.txt", @"Content/Levels/lvl3items.txt");
            SpawnEnemy1(enemyManager.enemyList);
            nextLevelPosX = 1200;
        }

        public void Update(GameTime gameTime)
        {
            if (Vitas.DEAD)
                nextLevelBox = new Rectangle(2870, (int)502, 40, 300);
            else
                nextLevelBox = new Rectangle(2870 + 2000, (int)335, 0, 0);

            contentLoader.Update(gameTime);
            CameraStopWhenEnemySpawn(playerManager, gameTime);

            //Om spelaren går i mål så kommer man att ha klarat av level 1 och level 2 ska börja
            for (int i = 0; i < playerManager.playerList.Count; i++)
                if (playerManager.playerList[i].boundingBox.Intersects(nextLevelBox))
                {
                    contentLoader.NextLevel(playerManager, enemyManager, 1200);
                    GameManager.levelNr++;
                }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            contentLoader.Draw(spriteBatch);
           // spriteBatch.Draw(TextureManager.lifeBarTex, nextLevelBox, Color.Black);
        }

        private void SpawnEnemy1(List<Enemy> enemyList)
        {
            enemyManager.enemyList.Add(new Vitas(TextureManager.standardEnemyTex, new Vector2(2800, 675), false, 4, playerManager.playerList));
        }

        public void CameraStopWhenEnemySpawn(PlayerManager playerManager, GameTime gameTime)
        {
            ContentLoader.levelEndPosX = 2862;
        }
    }
}
