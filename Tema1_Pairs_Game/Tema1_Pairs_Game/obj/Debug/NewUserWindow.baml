   M S B A M L   `   `   `  ����K  GTema1_Pairs_Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Tema1_Pairs_GameTema1_Pairs_Game  5   	   $    Tema1_Pairs_Game.NewUserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Tema1_Pairs_Game     5   	     � Title$  NewUserWindow��5   	   $	��450��6   $	��800��6,   .��5	      � ���#23262B � ColumnDefinitions 5
   
   �� 5      $	��30* �6   �� 5      $
��100* �6   �� 5      $	��50* �6   �� 5      $
��100* �6   �� 5      $	��30* �6    � RowDefinitions 5   
   �� 5      $	��70* �6   �� 5      $
��150* �6   �� 5      $
��100* �6   .+�5   
   �� $��P A I R S  G A M E��6   ���#525965$��Fonts/#Orbitron Medium)�5      $��10(�5      $��Bottom=�5      $��Right=�5      $��3��5      $��2��5      $��	0,0,15,10q�5       �� 5"   
   ���#D61734$��15��5#       �� CornerRadius$ 3,0,0,3��5$      $��5��5%      $��Bottom=�5&      $��Right=�5'      $��4��5(      $��2��5)      $��0,0,0,8q�5*      �� 5,   
   -   5         ��Name$ message1��5,      ���#FFFFFF$��1��5-      $��0��6$    �� TextAlignment$ Center=�5.      $
��Left=�6+   $��Center=�6F   $
��Wrap=�5/      $��Pick your username:��6(   $
��Bold"�6C   $	��110��6U   �� 50   
   -   5        $ message2��50      ���#FFFFFF$��3��51      $��0��6$   $ Center=�52      $
��Left=�6+   $��Center=�6F   $
��Wrap=�53      $��Pick your avatar picture:��6(   $
��Bold"�6I   $	��110��6[   �� 54   
   -   5        $��newUsernameTextBox��54      $��1��55      $��30��6   $	��100��6+   $
��Left=�67   $	��Top=�6R   $��2��6j   $��	77,45,0,0q�6~   �� 56   
   -   5        $��addNewUserButton��56      $	��Add��6B   $��1��57      $��1��6!   $��30��6.   $��70��6:   $��Right=�6E   $	��Top=�6a   $��	0,45,39,0q�6y   �� 59   
   -   5        $��avatarHolder��59      $��3��6$   $��1��64   $��Uniform=�6A   $��avatarImages/avatar1.jpg��6S   �� 5:   
   -   5        $��
prevAvatar��5:      $��previous��6<   $��3��5;      $��2��6!   $��30��6.   $��70��6:   $
��Left=�6E   �� 5<   
   -   5        $��
nextAvatar��5<      $
��next��6<   $��3��5=      $��2��6!   $��30��6.   $��70��6:   $��Right=�6E   5?      5@      