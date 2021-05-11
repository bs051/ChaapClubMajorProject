INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6038e952-5a05-48e9-aa24-657f643804ee', N'7bf614ea-26e0-4f2e-8d0a-c1b8442ea18d')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6038e952-5a05-48e9-aa24-657f643804ee', N'powerAdmin@ChaapClub.com', N'POWERADMIN@CHAAPCLUB.COM', N'powerAdmin@ChaapClub.com', N'POWERADMIN@CHAAPCLUB.COM', 1, N'AQAAAAEAACcQAAAAEAEGVwcnOxPuF4PgZZ8BO5Z4BXGkhKUPvnPOJ6PMWfwsdGtyiiA4UZ1qiVZq+kC3IA==', N'2STIVAX72HUFDS6SXMWLU7DYGKMQE6MY', N'b681a5de-e175-4e28-8245-5317f13eec21', NULL, 0, 0, NULL, 1, 0)
GO
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7bf614ea-26e0-4f2e-8d0a-c1b8442ea18d', N'power', N'power', N'168ebe74-34a0-4906-be15-17c0040a0c15')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'dfe1e8d6-8678-4af7-82b2-6fd0c2039d99', N'Navjot@gmail.com', N'NAVJOT@GMAIL.COM', N'Navjot@gmail.com', N'NAVJOT@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAELh75wZQTs586Unh/UU3rYHvp1z+V7ZfX7cX/oqE+j2CRaBuChBi61qKij6x65ddOg==', N'2PJ3UQIR562NPPWS545UWMG2B5LGCAOD', N'a9065e20-d4c7-47f6-8388-d2fada4b9e5f', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[YourChoices] ON 
GO
INSERT [dbo].[YourChoices] ([ChoiceID], [ChoiceName]) VALUES (1, N'No Maida Added')
GO
INSERT [dbo].[YourChoices] ([ChoiceID], [ChoiceName]) VALUES (2, N'Starters')
GO
INSERT [dbo].[YourChoices] ([ChoiceID], [ChoiceName]) VALUES (3, N'Rich Mushroom')
GO
SET IDENTITY_INSERT [dbo].[YourChoices] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodExpos] ON 
GO
INSERT [dbo].[FoodExpos] ([ExpoID], [ExpoName]) VALUES (1, N'Soya Chaap')
GO
INSERT [dbo].[FoodExpos] ([ExpoID], [ExpoName]) VALUES (2, N'Mushroom')
GO
INSERT [dbo].[FoodExpos] ([ExpoID], [ExpoName]) VALUES (3, N'Paneer')
GO
INSERT [dbo].[FoodExpos] ([ExpoID], [ExpoName]) VALUES (4, N'Wonton Momos')
GO

SET IDENTITY_INSERT [dbo].[FoodExpos] OFF
GO
SET IDENTITY_INSERT [dbo].[ChaapClubs] ON 
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (1, N'Soya Malai Chaap', N'Malai Soya Chaap curry is rich and spicy soya chaap recipe. Soya Chaap is cooked into creamy and mildly spiced flavourful masala gravy which is made with rich malai or milk cream.', N'.png', 5, 1, 1)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (2, N'Soya Achari Chaap', N'Maharaja Chaap offers Soya Achari Tikka which is marinated with curd and picking spicies. They are either cooked using grill or tawa', N'.png', 7, 1, 1)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (3, N'Soya Stuffed Chaap', N'It is a chaap made from soyabean flour with stuffing of paneer and masalas with outer coating of maida and cornflour.', N'.png', 10, 1, 1)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (4, N'Veg Fish Soya Chaap', N'A healthy vegetarian snack recipe prepared from soya bean which is rich in protein and is the best alternative to meat or chicken.', N'.png', 5, 1, 1)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (5, N'Soya Chaap Curry', N'soya chaap masala gravy recipe | soya chaap curry | soya chaap sabji.it is an ideal meat substitute indian curry that would provide the same texture and flavour as any meat-based curry.', N'.png', 10, 1, 1)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (6, N'Afghani Soya Chaap', N'Indulge yourself in a bit of Afghani taste with Afghani Chaap. It is a great and unique recipe with great taste.', N'.png', 5.5, 1, 1)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (7, N'Diet Lemon Soya Chaap', N'Diet Lemon Chaap is a vegetarian and protein diet as it is primarily made of soyabean. Crushed soyas are marinated in curd added with lemon juice and Indian spices including black pepper, crushed chilli and garlic paste. Coated chaap is either grilled or boiled in oil and served with onion rings and lemon wedges', N'.png', 8, 1, 1)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (8, N'Crispy fried Soya Chaap or KFC Chaap', N'Soya chaap is a delicious protein rich recipe you will relish for sure. You might have eaten soya chaap curry on various occasions, it is time you try out Crispy fried soya chaap.', N'.png', 5.5, 1, 1)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (9, N'Kali Mirch Or Black Pepper Soya Chaap', N'Kali Mirch Chaap is made mixing soya cubes with curd, cumin powder, pepper powder, garam masala, ginger-garlic paste and salt and leave for marinade for few hours. Use kali mirch to balance the pungency of the black pepper.', N'.png', 8, 1, 1)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (10, N'Crispy Fried Paneer Momos', N'Homemade momos with a flavourful paneer stuffing and I made the outer covering dough with maida. ', N'.png', 5, 2, 4)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (11, N'Malai Paneer Tikka', N'Grilled Cottage Cheese With Cream is a appetizer made by marinating paneer/cottage cheese and vegetables  with a mild marinade that is  made with cream, hung curd, cashew nut powder and flavored with kasurimethi, fennel seeds and cardamom powder. This  marinated paneer and vegetables are than grilled either in a griller, oven or open barbeque or gas flame. ', N'.png', 11, 2, 3)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (12, N'Lemon Paneer Tikka', N'The tikka is an amalgamation of flavour charred veggies and paneer, hint of sour curd, chaat masala, spicy yet balanced taste with right duration of marinate. Serving with coriander-mint chutney brings the perfect balance to this traditional dish.', N'.png', 10, 2, 3)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (13, N'Chilli Paneer Tikka', N'Chilli Paneer recipe, the fried paneer cubes are tossed in a sweet, sour, spicy sauce. The paneer cubes can be coated with flours or batter coated and deep fried.', N'.png', 12.5, 2, 3)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (14, N'Mushroom Tikka', N'Mushrooms are coated with a almond milk yogurt based marinade and then roasted in the oven until cooked and little charred', N'.png', 8.5, 2, 2)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (15, N'Mushroom Duplex', N'Mushroom duplex is a stuffed mushroom recipe where mushrooms are filled with cheese, vegetables and spices. It  is then coated with fine quality bread crumbs and deep fried in oil till crisp golden', N'.png', 11, 3, 2)
GO
INSERT [dbo].[ChaapClubs] ([ClubID], [FoodName], [Description], [Extension], [Price], [ChoiceID], [ExpoID]) VALUES (16, N'Malai Mushroom Tikka', N'Malai Mushroom Tikka is a starter that will tantalize your taste buds and leave you wanting for more. They are absolutely easy to make and just the perfect creamy cheesy starter for your meals.', N'.png', 11, 3, 2)
GO
SET IDENTITY_INSERT [dbo].[ChaapClubs] OFF
GO
 