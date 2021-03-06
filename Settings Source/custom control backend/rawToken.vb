﻿Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class rawToken
    Private m_optionOnValue As String = ""
    Private m_optionOffValue As String = ""
    Private m_tokenName As String = ""

    Public Sub New()
    End Sub

    Public Overrides Function ToString() As String
        Return m_tokenName & " ON:" & m_optionOnValue & " OFF:" & m_optionOffValue
    End Function

    <CategoryAttribute("Data"),
    DisplayNameAttribute("Token"),
    DescriptionAttribute("The name of the token. Not required if performing replacement.")> _
    Public Property tokenName As String
        Get
            Return m_tokenName
        End Get
        Set(value As String)
            m_tokenName = value
        End Set
    End Property

    <CategoryAttribute("Data"),
    DisplayNameAttribute("Enabled Value"),
    DescriptionAttribute("This is the value to use in the files when this option is ENABLED.")> _
    Public Property optionOnValue As String
        Get
            Return m_optionOnValue
        End Get
        Set(value As String)
            m_optionOnValue = value
        End Set
    End Property

    <CategoryAttribute("Data"),
    DisplayNameAttribute("Disabled Value"),
    DescriptionAttribute("This is the value to use in the files when this option is DISABLED.")> _
    Public Property optionOffValue As String
        Get
            Return m_optionOffValue
        End Get
        Set(value As String)
            m_optionOffValue = value
        End Set
    End Property

End Class

Public Class rawTokenCollection
    Inherits CollectionBase

    Public ReadOnly Property Item(index As Integer) As rawToken
        Get
            Return DirectCast(List(index), rawToken)
        End Get
    End Property

    Public Sub Add(ByVal t As rawToken)
        List.Add(t)
    End Sub

    Public Sub Remove(ByVal t As rawToken)
        List.Remove(t)
    End Sub

    Public Sub Replace(ByVal t As rawToken, ByVal index As Integer)
        If List.Count > 0 And index < List.Count - 1 Then
            List.RemoveAt(index)
            List.Insert(index, t)
        End If
    End Sub
End Class

Public Class rawTokenCollectionEditor
    Inherits CollectionEditor

    Public Sub New()
        MyBase.New(GetType(rawTokenCollection))
    End Sub
End Class
