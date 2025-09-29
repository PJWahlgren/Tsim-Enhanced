using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using Tsim.View;

namespace Tsim;

public class Game1 : Core
{

    private AnimatedSprite _redLight;
    private Sprite _track;

    private Sprite _turnTrack;
    private World world;
    private WorldRender worldRender;

    // The MonoGame logo texture
    private Texture2D _logo;
    public Game1() : base("Tsim Enhanced", 1280, 720, false)
    {
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        _logo = Content.Load<Texture2D>("images/logo");

        // Create the texture atlas from the XML configuration file
        TextureAtlas tsimTexture = TextureAtlas.FromFile(Content, "images/tsim-definition.xml");

        world = new World(5);
        worldRender = new WorldRender(world, tsimTexture);
        _track = tsimTexture.CreateSprite("forward-track");
        _track.Scale = new Vector2(4.0f);
        _turnTrack = tsimTexture.CreateSprite("turn-track");

        _redLight = tsimTexture.CreateAnimatedSprite("red-light-animation");
        _redLight.Scale = new Vector2(16.0f);

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        _redLight.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Orange);

        // TODO: Add your drawing code here

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        worldRender.Draw(SpriteBatch, Vector2.Zero);
        _track.Draw(SpriteBatch, Vector2.Zero);
        _redLight.Draw(SpriteBatch, Vector2.One);
        // Always end the sprite batch when finished.
        SpriteBatch.End();
        base.Draw(gameTime);
    }
}
