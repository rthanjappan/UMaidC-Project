   M S B A M L   `   `   `  ����G  CUMaid_Window, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UMaid_WindowUMaid_Window  5   	   )    #UMaid_Window.CustomerMainMenuWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:UMaid_Window     5   	     � Title$  Customer Main Menu��5   	   $	��500��5	   	   $	��550��5
   	   .��5      �  � ShowGridLines .   � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ spMain��5   .    �� Orientation$ 
Horizontal=�6   $��
20,10,20,0q�6>   $��0��6R   $	��400��6_   $	��Top=�6l   .+�5      �� $��Customer Main Menu��6   $��20(�61   
����ح�$��Center=�5      $��
20,10,20,0q�6-   $	��Top=�6A   $	��250��6Y   �� 5      -   5         ��Name$ 	btnLogout��5      $��Logout��6(   $��30��6Q   $��80��6]   $��	70,10,0,0q�6h   $	��Top=�6{   5      �� 5   
   -   5        $ 	spButtons��5   ,   $ Vertical=�6   $��20,100,20,0q�6?   $��0��6T   $	��400��6a   $	��Top=�6n   .+�5      �� -   5        $ 
btnProfile��5      $��Edit Profile��6)   $	��100��6g   $��30��6t   $��10q�6�   $	��Top=�6�   �� 5      -   5        $ btnManageProperty��5      $��Manage Property��60   $��10q�6p   $��30��6|   $	��100��6�   $	��Top=�6�   �� 5      -   5        $ btnManageListing��5      $��Manage Listing��6/   $��10q�6m   $��30��6y   $	��100��6�   $	��Top=�6�   �� 5      -   5        $ btnViewActiveBids��5      $��View Active Bids��60   $��10q�6j   $��30��6w   $	��100��6�   $	��Top=�6�   5      �� 5   
   $��1q�6   
���   �$	��500��69   $	��150��6E   $��1��6R   ._�5      �� -   5        $ spInfo��5   0   $ Vertical=�6   $��
30,20,30,0q�6@   .+�5      �� $��User Info (Debug)��6   $
��Left=�5      $��Center=�5      $
��1000��5       �� 5!      $��Email:��6   $
��Left=�5"      $��Center=�5#      �� 5$      $
��Left=�5%      $��Center=�5&      ��5$      �� *Email+5&      �� 5'      $��	Password:��6   $
��Left=�5(      $��Center=�5)      �� 5*      $
��Left=�5+      $��Center=�5,      ��5*      �� *
Password+5,      �� 5-      $��	UserType:��6   $
��Left=�5.      $��Center=�5/      �� 50      -	   5         ��Name$ 
tbUserType��50      $
��Left=�51      $��Center=�52      53      54      55      56      