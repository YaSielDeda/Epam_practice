   M S B A M L   `   `   `  ����R  NEPAM.FileStorage.WPF-PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:EPAM.FileStorage.WPF_PLEPAM.FileStorage.WPF_PL  5   	   3    -EPAM.FileStorage.WPF_PL.CreateNewFileOrFolder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:EPAM.FileStorage.WPF_PL     5   	     � Title$  CreateNewFileOrFolder��5   	   $��251.425��6'   $��331.864��68    � 
ResizeMode$ NoResize=�6H   .��5	      � .+�5
   
   �� $��Enter the name��6   $
��Left=�6)   $��	53,46,0,0q�6D   $	��Top=�6W   �� 5   
   -   5         ��Name$ TextBoxName��5      $
��Left=�6'   $��23��6B   $��	55,71,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��202��6�   �� 5   
   -   5         ��Name$ CancelCreateButton��5      $��Cancel��6-   $
��Left=�6>   $��
72,153,0,0q�6Y   $	��Top=�6m   $��75��6�   6�   	� 5   
   -   5         	�Name$ FileRadioButton��5      $��	Text file��6/   $
��Left=�6C   $��
55,103,0,0q�6^   $	��Top=�6r   	� 5   
   -   5        $ FolderRadioButton��5      $��Folder��61   $
��Left=�6B   $��
55,124,0,0q�6]   $	��Top=�6q   �� 5   
   -   5        $ ConfirmCreateButton��5      $��OK��6.   $
��Left=�6;   $��168,153,0,0q�6V   $	��Top=�6k   $��75��6�   6�   5      5      