﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Specializations.Projectiles
{
    public class AdamantiteBone : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bone);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y); 
            Vector2 usePos = projectile.position;
                                                
            for (int i = 0; i < 6; i++)
            {
               Dust.NewDust(usePos, 8, 8, 1);
            }

            int item = Main.rand.Next(2) == 0 ? Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("AdamantiteBone")) : 0;

            if (Main.netMode == 1 && item >= 0)
            {
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
            }
        }
    }
}