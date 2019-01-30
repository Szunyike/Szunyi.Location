Imports System.Runtime.CompilerServices
Imports Bio.IO.GenBank
<Flags()>
Public Enum Locations_By As Integer
    ''' <summary>
    ''' Transcription Start Site
    ''' </summary>
    TSS = 1
    ''' <summary>
    ''' Transcription End Site
    ''' </summary>
    PAS = 2
    ''' <summary>
    ''' Location Start
    ''' </summary>
    LS = 4
    ''' <summary>
    ''' Location End
    ''' </summary>
    LE = 8
    Intron = 16

End Enum

Public Module Location_Extensions
    ''' <summary>
    ''' Return Current Position based on User-Defined Enumeration
    ''' </summary>
    ''' <param name="Location"></param>
    ''' <param name="Loc_By"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Current_Position(Location As Bio.IO.GenBank.Location, Loc_By As Locations_By) As Integer
        Select Case Loc_By
            Case Locations_By.LE
                Return Location.LocationEnd
            Case Locations_By.LS
                Return Location.LocationStart
            Case Locations_By.PAS
                Return Location.PAS
            Case Locations_By.TSS
                Return Location.TSS
            Case Else
                Return 0
        End Select

    End Function
    ''' <summary>
    ''' Return Current Position based on User-Defined Enumeration
    ''' </summary>
    ''' <param name="Location"></param>
    ''' <param name="Loc_By"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Current_Position(Location As Bio.IO.GenBank.ILocation, Loc_By As Locations_By) As Integer
        Select Case Loc_By
            Case Locations_By.LE
                Return Location.LocationEnd
            Case Locations_By.LS
                Return Location.LocationStart
            Case Locations_By.PAS
                Return Location.PAS
            Case Locations_By.TSS
                Return Location.TSS
            Case Else
                Return 0
        End Select
    End Function
    ''' <summary>
    ''' Return Location Start if LociOperator or FirestSublocation operator is not Complement, Else return the LocationEnd
    ''' </summary>
    ''' <param name="Location"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function TSS(Location As Bio.IO.GenBank.Location) As Integer
        If Location.Operator = LocationOperator.Complement Then
            Return Location.LocationEnd
        ElseIf Location.Operator = LocationOperator.Join AndAlso Location.SubLocations.Count > 0 AndAlso Location.SubLocations.First.Operator = LocationOperator.Complement Then
            Return Location.LocationEnd
        Else
            Return Location.LocationStart
        End If
    End Function
    ''' <summary>
    ''' Return Location End if LociOperator or FirestSublocation operator is not Complement, Else return the LocationStart
    ''' </summary>
    ''' <param name="Location"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function PAS(Location As Bio.IO.GenBank.Location) As Integer
        If Location.Operator = LocationOperator.Complement Then
            Return Location.LocationStart
        ElseIf Location.Operator = LocationOperator.Join AndAlso Location.SubLocations.Count > 0 AndAlso Location.SubLocations.First.Operator = LocationOperator.Complement Then
            Return Location.LocationStart
        Else
            Return Location.LocationEnd
        End If
    End Function
    ''' <summary>
    ''' Return true or false depend the Location or First Sublocation Operator
    ''' </summary>
    ''' <param name="Location"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function IsComplementer(Location As Bio.IO.GenBank.Location) As Boolean
        If Location.Operator = LocationOperator.Complement Then
            Return True
        ElseIf Location.Operator = LocationOperator.Join AndAlso Location.SubLocations.Count > 0 AndAlso Location.SubLocations.First.Operator = LocationOperator.Complement Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' Return Location Start if LociOperator or FirestSublocation operator is not Complement, Else return the LocationEnd
    ''' </summary>
    ''' <param name="Location"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function TSS(Location As Bio.IO.GenBank.ILocation) As Integer
        If Location.Operator = LocationOperator.Complement Then
            Return Location.LocationEnd
        ElseIf Location.Operator = LocationOperator.Join AndAlso Location.SubLocations.Count > 0 AndAlso Location.SubLocations.First.Operator = LocationOperator.Complement Then
            Return Location.LocationEnd
        Else
            Return Location.LocationStart
        End If
    End Function
    ''' <summary>
    ''' Return Location End if LociOperator or FirestSublocation operator is not Complement, Else return the LocationStart
    ''' </summary>
    ''' <param name="Location"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function PAS(Location As Bio.IO.GenBank.ILocation) As Integer
        If Location.Operator = LocationOperator.Complement Then
            Return Location.LocationStart
        ElseIf Location.Operator = LocationOperator.Join AndAlso Location.SubLocations.Count > 0 AndAlso Location.SubLocations.First.Operator = LocationOperator.Complement Then
            Return Location.LocationStart
        Else
            Return Location.LocationEnd
        End If
    End Function
    ''' <summary>
    ''' Return true or false depend the Location or First Sublocation Operator
    ''' </summary>
    ''' <param name="Location"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function IsComplementer(Location As Bio.IO.GenBank.ILocation) As Boolean
        If Location.Operator = LocationOperator.Complement Then
            Return True
        ElseIf Location.Operator = LocationOperator.Join AndAlso Location.SubLocations.Count > 0 AndAlso Location.SubLocations.First.Operator = LocationOperator.Complement Then
            Return True
        Else
            Return False
        End If
    End Function


End Module
