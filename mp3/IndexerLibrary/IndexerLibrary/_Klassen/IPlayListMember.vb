Option Explicit On
Option Strict On
Option Infer On

	Public Enum PlayListMemberTypes
		Title = 0
		PlayList = 1
	End Enum

	Public Interface IPlayListMember
		ReadOnly Property FileName() As String
		ReadOnly Property PlayListMember() As PlayListMemberTypes
		Function ToString() As String
	End Interface




