Option Explicit On
Option Strict On
Option Infer On

Namespace Data

	Public Interface IPlayListMember
		Property FileName() As String
		ReadOnly Property PlayListMember() As PlayListMemberTypes
		Function ToString() As String
	End Interface

End Namespace




