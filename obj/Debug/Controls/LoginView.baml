   M S B A M L   `   `   `  ����C  ?SQLTABLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SQLTABLESQLTABLE  5   	       SQLTABLE.LoginView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SQLTABLE     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.0.1244, Culture=neutral, PublicKeyToken=null;wpf1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	Logowanie��5	   	   $	��350��5
   	   $	��525��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency .  � WindowStyle$
 None=�5   	   ��5      �� 5   
    �� Opacity$ 0Q�6    �� Color$ White��6&   .��5      #  MaterialDesignThemes.Wpf.Card  $��5q�6   $��8q�6   .��5      � -   5        ��5   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      � 	 � Color$	 #008eab��6   
 � Offset$
 1Q�6/   � 5      $	 #006622��6   $
 0Q�6/   5      .+�5   
   �� -   5        $	��310��5      $	��Top=�6    �� CornerRadius$ 0 0 60 0��66   ���#100E175      '  !MaterialDesignThemes.Wpf.PackIcon  5   
   -   5          Name$ network_icon��5       � ToolTip$? 9Kliknij dwa razy by ponowić połączenie z bazą danych.��6-      Kind$ Network=�6m   $��25��6|   $��25��6�   
���  ��$��5 5 0 0q�6�   �� 5!      $-��'../Images/Groups-Meeting-Light-icon.png��6   $	��128��6B   $��
0 0 0 250 q�6N   6d   � 5$   
   -   5         �Name$ ProgressBar��5$      $	��400��6+   $��	0 150 0 0q�67   
��� �� � IsIndeterminate . 6{   �� 5%   
   -   5         ��Name$ TextBlockWait��5%      $%��Czekam na połączenie z bazą.��6+   
�������$��170 240 0 0q�6a   6x   �� 5&   
   $	��0 0q�6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5)   
   �� $��90 80q�6   .+�5*   
   �� $ 
Horizontal=�6   $
��70 5q�6.   .+�5,        $
 User=�6   $��25��6'   $��25��62   
�������6>   �� 5-      -   5         ��Name$ txtUsername��5-   #   $��admin��6   $  Wpisz nazwę użytkownika.��68   $
��10 0q�6[   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  ��6i   
���   �
�������$	��250��6�   ���#3d3d3d �� 
CaretBrush �	#FFD94448 �� SelectionBrush �	#FFD944486�   5.      �� 50      $ 
Horizontal=�6   $
��70 5q�62   .+�52        $
 Lock=�6   $��25��6+   $��25��66   
�������6B   G� 53      -   5         G�Name$ txtPassword��53   .    G� Password$
 1234��6   $  Wpisz hasło użytkownika.��6C   $
��10 0q�6f   $ ********��6t   
���   �
�������$	��250��6�   ���#3d3d3d G� 
CaretBrush �	#FFD94448 G� SelectionBrush �	#FFD944486�   55      �� 57      .+�58      �� -   5         ��Name$ btnLogin��59   -   $	��100��58      $��40��6%   $��140 10q�61   $ Kliknij by zalogować.��6A   ��59   V   Z� .��5:   )     $ Login=�66   $��35��6C   $��35��6N   
�������6Z   5;   '   5=      5?      �� 5A      $��-170 5 25 0q�6   .+�5B      �� -	   5        $ btnExit��5B   C   $��40��6   $��70��6&   $ Zamknij��61   ��6j   Z� .��5C        $ Close=�6#   
�������$��32��6C   $��32��6N   5D      5F      5H      5L      5M      5N      