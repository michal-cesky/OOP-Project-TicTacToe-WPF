   M S B A M L   `   `   `  ����P  LOOP-Project-TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OOP_Project_TicTacToeOOP_Project_TicTacToe  5   	   '    !OOP_Project_TicTacToe.PlayersName   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:OOP_Project_TicTacToe     5   	     � Title$  PlayersName��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��43* �6   �� 5      $
��174* �6   .+�5   
   �� -   5         ��Name$ textboxPlayer1��5      $
��Left=�6*   $��30��6E   $��	83,54,0,0q�6Q    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��226��6�   $��1��6�   �� 5   
   -   5        $ textboxPlayer2��5      $
��Left=�6*   $��30��6E   $��
494,54,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6y   $	��226��6�   $��1��6�   �� 5   
   -   5         ��Name$ buttonSelectField��5      $
��Next��6,   $
��Left=�6;   $��56��6V   $��270,148,0,0q�6b   $	��Top=�6w   $	��255��6�   $��1��6�   �� 5   
   -   5        $ buttonLoadNames��5      $
��Left=�6*   $��56��6E   $��270,209,0,0q�6Q   $	��Top=�6f   $	��255��6~    J� RenderTransformOrigin$ 0.386,-2.949&�6�   $��1��6�   $��Load names from last game��6�   �� 5   
   -   5        $ 
buttonBack��5      $
��Back��6%   $
��Left=�64   $��56��6O   $��270,270,0,0q�6[   $	��Top=�6p   $	��255��6�   $��1��6�   �� 5   
   -   5         ��Name$ SelectnamePlayer1��5      $��Select name Player1��6+   $
��Left=�6I   $��39��6d   $��	83,86,0,0q�6p   $	��Top=�6�   $	��226��6�   $
��Bold"�6�   $��Center=�6�   $��20(�6�   $��2��6�   �� 5   
   -   5        $ SelectnamePlayer2��5      $��Select name Player2��6+   $
��Left=�6I   $��39��6d   $��
494,86,0,0q�6p   $	��Top=�6�   $	��226��6�   $
��Bold"�6�   $��Center=�6�   $��20(�6�   $��2��6�   5      5      