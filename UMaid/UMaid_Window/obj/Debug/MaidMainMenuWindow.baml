   M S B A M L   `   `   `  ����G  CUMaid_Window, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UMaid_WindowUMaid_Window  5   	   %    UMaid_Window.MaidMainMenuWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:UMaid_Window     5   	     � Title$  MaidMainMenu��5   	   $	��450��6   $	��700��6+   .��5	      �  � ShowGridLines .   � RowDefinitions 5
   
   �� 5      $
��1.5* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ spMain��5   .    �� Orientation$ 
Horizontal=�6   $��
20,10,20,0q�6>   $��0��6R   $	��400��6_   $	��Top=�6l   .+�5      �� $��Maid Main Menu��6   $��20(�6-   
����ح�$��Center=�5      $��200,10,50,0q�6-   $	��Top=�6B   $	��250��6Z   �� 5      -   5         ��Name$ 	btnLogout��5      $��Logout��6(   $��30��6Q   $��80��6]   $��	50,10,0,0q�6h   $	��Top=�6{   5      �� 5   
   -   5        $ 	spButtons��5   ,   $ Vertical=�6   $��
20,10,20,0q�6?   $��0��6S   $	��400��6`   $	��Top=�6m   .+�5      �� -   5        $��btnProfileInfo��5      $��Change Profile Info��6H   
�������$��20(�6~   $��Center=�6�   $��	0,100,0,0q�6�   $	��Top=�6�   $	��200��6�   �� 5      -   5        $��btnSearchListing��5      $��Search Listing��6L   
�������$��20(�6}   $��Center=�6�   $��0,30,0,0q�6�   $	��Top=�6�   $	��200��6�   5      �� 5   
   -   5        $ spInfo��5   ,   $ Vertical=�6   $��
30,20,30,0q�6<   $��1��6P   .+�5      �� $��User Info (Debug)��6   $
��Left=�5      $��Center=�5      $
��1000��5      �� 5      $��Email:��6   $
��Left=�5      $��Center=�5      �� 5      $
��Left=�5       $��Center=�5!      ��5      �� *Email+5!      �� 5"      $��	Password:��6   $
��Left=�5#      $��Center=�5$      �� 5%      $
��Left=�5&      $��Center=�5'      ��5%      �� *
Password+5'      �� 5(      $��
User Type:��6   $
��Left=�5)      $��Center=�5*      �� 5+      -   5         ��Name$ 
tbUserType��5+      $
��Left=�5,      $��Center=�5-      5.      5/      50      