using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Specializations.Items.Guns
{
	public class MythrilShotgun : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 30;
			item.height = 7;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 90000;
			item.rare = 4;
			item.UseSound = SoundID.Item41;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
		int numberProjectiles = 3 + Main.rand.Next(2); 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		
		public override Vector2?HoldoutOffset()
		{
			return new Vector2(0, 1);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MythrilBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	
	}
}
