﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using OpenTK;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Beatmaps.Drawables;
using osu.Game.Database;
using osu.Game.Online.Multiplayer;

namespace osu.Game.Screens.Multiplayer
{
    public class ModeTypeInfo : Container
    {
        private const float height = 30;
        private const float transition_duration = 100;

        private readonly Container rulesetContainer, gameTypeContainer;

        public BeatmapInfo Beatmap
        {
            set
            {
                if (value != null)
                {
                    rulesetContainer.FadeIn(transition_duration);
                    rulesetContainer.Children = new[]
                    {
                        new DifficultyIcon(value)
                        {
                            Size = new Vector2(height),
                        }
                    };
                }
                else
                {
                    rulesetContainer.FadeOut(transition_duration);
                }
            }
        }

        public GameType Type
        {
            set
            {
                gameTypeContainer.Children = new[]
                {
                    new DrawableGameType(value)
                    {
                        Size = new Vector2(height),
                    },
                };
            }
        }

        public ModeTypeInfo()
        {
            AutoSizeAxes = Axes.Both;

            Children = new[]
            {
                new FillFlowContainer
                {
                    Anchor = Anchor.BottomRight,
                    Origin = Anchor.BottomRight,
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Horizontal,
                    LayoutDuration = transition_duration,
                    Spacing = new Vector2(5f, 0f),
                    Children = new[]
                    {
                        rulesetContainer = new Container
                        {
                            AutoSizeAxes = Axes.Both,
                        },
                        gameTypeContainer = new Container
                        {
                            AutoSizeAxes = Axes.Both,
                        },
                    },
                },
            };
        }
    }
}
