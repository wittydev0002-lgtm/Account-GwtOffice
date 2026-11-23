
Imports System.Collections.Generic
Imports System.Text


Public Class Song

    Public Sub New()
    End Sub

    Public Sub New(title As String, artist As String, sizeInBytes As Long, album As String, rating As Integer, lastPlayed As DateTime)
        Me.Title = title
        Me.Artist = artist
        Me.Album = album
        Me.LastPlayed = lastPlayed
        Me.SizeInBytes = sizeInBytes
        Me.Rating = rating
    End Sub

    Public Property Title() As String
        Get
            Return m_title
        End Get
        Set(value As String)
            m_title = value
        End Set
    End Property
    Private m_title As String

    Public Property Artist() As String
        Get
            Return m_artist
        End Get
        Set(value As String)
            m_artist = value
        End Set
    End Property
    Private m_artist As String

    Public Album As String

    Public Property LastPlayed() As DateTime
        Get
            Return m_lastPlayed
        End Get
        Set(value As DateTime)
            m_lastPlayed = value
        End Set
    End Property
    Private m_lastPlayed As DateTime

    Public Property SizeInBytes() As Long
        Get
            Return m_sizeInBytes
        End Get
        Set(value As Long)
            m_sizeInBytes = value
        End Set
    End Property
    Private m_sizeInBytes As Long

    ' Public field just to show that it works.
    Public Rating As Integer

    Public Function GetSizeInMb() As Double
        Return CDbl(Me.SizeInBytes) / (1024.0 * 1024.0)
    End Function

    ' What follows are DB-like functions

    Friend Shared Function GetArtists() As List(Of ArtistExample)
        If Song.AllArtists.Count = 0 Then
            Song.AllArtists = Song.InitializeArtists()
        End If
        Return Song.AllArtists
    End Function
    Private Shared AllArtists As New List(Of ArtistExample)()

    Friend Shared Function GetSongs() As List(Of Song)
        If Song.AllSongs.Count = 0 Then
            Song.AllSongs = Song.InitializeSongs()
        End If
        Return Song.AllSongs
    End Function
    Private Shared AllSongs As New List(Of Song)()

    Friend Shared Function InitializeArtists() As List(Of ArtistExample)
        Dim alreadySeen As New Dictionary(Of String, Boolean)()
        Dim artists As New List(Of ArtistExample)()
        For Each s As Song In Song.GetSongs()
            If Not alreadySeen.ContainsKey(s.Artist) Then
                alreadySeen(s.Artist) = True
                artists.Add(New ArtistExample(s.Artist))
            End If
        Next
        Return artists
    End Function

    Friend Shared Function GetAlbumsForArtist(artist As String) As List(Of AlbumExample)
        Dim alreadySeen As New Dictionary(Of String, Boolean)()
        Dim albums As New List(Of AlbumExample)()
        For Each s As Song In Song.GetSongs()
            If s.Artist = artist AndAlso Not alreadySeen.ContainsKey(s.Album) Then
                alreadySeen(s.Album) = True
                albums.Add(New AlbumExample(s.Album))
            End If
        Next
        Return albums
    End Function

    Friend Shared Function GetSongsForAlbum(title As String) As List(Of Song)
        Dim alreadySeen As New Dictionary(Of String, Boolean)()
        Dim songs As New List(Of Song)()
        For Each s As Song In Song.GetSongs()
            If s.Album = title AndAlso Not alreadySeen.ContainsKey(s.Title) Then
                alreadySeen(s.Title) = True
                songs.Add(s)
            End If
        Next
        Return songs
    End Function

    Private Shared Function InitializeSongs() As List(Of Song)
        Dim songs As New List(Of Song)()

        songs.Add(New Song("Zoo Station", "U2", 5501234, "Achtung Baby", 60, New DateTime(2007, 10, 21, 5, 42, 0)))
        songs.Add(New Song("Who's Gonna Ride Your Wild Horses", "U2", 6301234, "Achtung Baby", 80, New DateTime(2007, 10, 9, 11, 32, 0)))
        songs.Add(New Song("So Cruel", "U2", 6901234, "Achtung Baby", 60, New DateTime(2007, 10, 9, 11, 38, 0)))
        songs.Add(New Song("The Fly", "U2", 5401234, "Achtung Baby", 60, New DateTime(2007, 10, 9, 11, 42, 0)))
        songs.Add(New Song("Tryin' To Throw Your Arms Around The World", "U2", 4701234, "Achtung Baby", 60, New DateTime(2007, 10, 9, 11, 46, 0)))
        songs.Add(New Song("Ultraviolet (Light My Way)", "U2", 6601234, "Achtung Baby", 60, New DateTime(2007, 10, 9, 11, 52, 0)))
        songs.Add(New Song("Acrobat", "U2", 5401234, "Achtung Baby", 60, New DateTime(2007, 10, 9, 11, 56, 0)))
        songs.Add(New Song("Love Is Blindness", "U2", 5301234, "Achtung Baby", 60, New DateTime(2007, 10, 9, 12, 0, 0)))
        songs.Add(New Song("Elevation", "U2", 4501234, "All That You Can't Leave Behind", 60, New DateTime(2008, 1, 25, 11, 46, 0)))
        songs.Add(New Song("Walk On", "U2", 5801234, "All That You Can't Leave Behind", 100, New DateTime(2008, 3, 18, 11, 39, 0)))
        songs.Add(New Song("Kite", "U2", 5201234, "All That You Can't Leave Behind", 40, New DateTime(2008, 1, 23, 10, 36, 0)))
        songs.Add(New Song("In A Little While", "U2", 4301234, "All That You Can't Leave Behind", 60, New DateTime(2008, 1, 20, 7, 48, 0)))
        songs.Add(New Song("Wild Honey", "U2", 4501234, "All That You Can't Leave Behind", 40, New DateTime(2007, 4, 13, 11, 50, 0)))
        songs.Add(New Song("Peace On Earth", "U2", 5601234, "All That You Can't Leave Behind", 40, New DateTime(2007, 12, 22, 2, 51, 0)))
        songs.Add(New Song("When I Look At The World", "U2", 5101234, "All That You Can't Leave Behind", 40, New DateTime(2007, 12, 22, 2, 55, 0)))
        songs.Add(New Song("New York", "U2", 6401234, "All That You Can't Leave Behind", 60, New DateTime(2007, 12, 22, 3, 1, 0)))
        songs.Add(New Song("Grace", "U2", 6501234, "All That You Can't Leave Behind", 40, New DateTime(2007, 12, 22, 3, 6, 0)))
        songs.Add(New Song("The Ground Beneath Her Feet(Bonus Song)", "U2", 4401234, "All That You Can't Leave Behind", 40, New DateTime(2007, 12, 22, 3, 10, 0)))
        songs.Add(New Song("Follow You Home", "Nickelback", 601234, "All The Right Reasons", 40, New DateTime(2008, 3, 6, 10, 42, 0)))
        songs.Add(New Song("Fight For All The Wrong Reason", "Nickelback", 5201234, "All The Right Reasons", 60, New DateTime(2008, 3, 15, 5, 4, 0)))
        songs.Add(New Song("Photograph", "Nickelback", 601234, "All The Right Reasons", 60, New DateTime(2008, 3, 15, 5, 8, 0)))
        songs.Add(New Song("Animals", "Nickelback", 4301234, "All The Right Reasons", 40, New DateTime(2008, 2, 16, 12, 12, 0)))
        songs.Add(New Song("Savin' Me", "Nickelback", 5101234, "All The Right Reasons", 80, New DateTime(2008, 3, 24, 10, 41, 0)))
        songs.Add(New Song("Far Away", "Nickelback", 5501234, "All The Right Reasons", 40, New DateTime(2008, 3, 15, 5, 30, 0)))
        songs.Add(New Song("Next Contestant", "Nickelback", 501234, "All The Right Reasons", 80, New DateTime(2008, 3, 24, 9, 47, 0)))
        songs.Add(New Song("Side Of A Bullet", "Nickelback", 4201234, "All The Right Reasons", 40, New DateTime(2008, 3, 6, 11, 0, 0)))
        songs.Add(New Song("If Everyone Cared", "Nickelback", 501234, "All The Right Reasons", 60, New DateTime(2008, 3, 6, 11, 3, 0)))
        songs.Add(New Song("Someone That You're With", "Nickelback", 5601234, "All The Right Reasons", 40, New DateTime(2008, 2, 16, 12, 34, 0)))
        songs.Add(New Song("Rockstar", "Nickelback", 5901234, "All The Right Reasons", 60, New DateTime(2008, 2, 16, 12, 38, 0)))
        songs.Add(New Song("Lelani", "Hoodoo Gurus", 5901234, "Ampology", 60, New DateTime(2007, 10, 22, 8, 45, 0)))
        songs.Add(New Song("Tojo", "Hoodoo Gurus", 4101234, "Ampology", 60, New DateTime(2007, 10, 22, 8, 48, 0)))
        songs.Add(New Song("My Girl", "Hoodoo Gurus", 3301234, "Ampology", 80, New DateTime(2007, 11, 12, 7, 57, 0)))
        songs.Add(New Song("Be My Guru", "Hoodoo Gurus", 3301234, "Ampology", 100, New DateTime(2008, 3, 20, 12, 15, 0)))
        songs.Add(New Song("I Want You Back", "Hoodoo Gurus", 3901234, "Ampology", 80, New DateTime(2007, 11, 12, 7, 42, 0)))
        songs.Add(New Song("I Was A Kamikaze Pilot", "Hoodoo Gurus", 3901234, "Ampology", 60, New DateTime(2007, 10, 22, 9, 0, 0)))
        songs.Add(New Song("Bittersweet", "Hoodoo Gurus", 4701234, "Ampology", 60, New DateTime(2007, 10, 22, 9, 4, 0)))
        songs.Add(New Song("Poison Pen", "Hoodoo Gurus", 501234, "Ampology", 60, New DateTime(2007, 10, 22, 9, 11, 0)))
        songs.Add(New Song("In The Wild", "Hoodoo Gurus", 3901234, "Ampology", 60, New DateTime(2007, 10, 22, 9, 14, 0)))
        songs.Add(New Song("Whats My Scene?", "Hoodoo Gurus", 4601234, "Ampology", 100, New DateTime(2007, 11, 12, 7, 51, 0)))
        songs.Add(New Song("Heart Of Darkness", "Hoodoo Gurus", 3801234, "Ampology", 60, New DateTime(2007, 10, 22, 9, 21, 0)))
        songs.Add(New Song("Good Times", "Hoodoo Gurus", 3701234, "Ampology", 80, New DateTime(2008, 3, 20, 12, 18, 0)))
        songs.Add(New Song("Cajun Country", "Hoodoo Gurus", 4901234, "Ampology", 60, New DateTime(2007, 10, 22, 9, 28, 0)))
        songs.Add(New Song("Axegrinder", "Hoodoo Gurus", 4201234, "Ampology", 60, New DateTime(2007, 10, 22, 9, 32, 0)))
        songs.Add(New Song("Another World", "Hoodoo Gurus", 401234, "Ampology", 80, New DateTime(2008, 3, 20, 12, 21, 0)))
        songs.Add(New Song("Meant To Live", "Switchfoot", 401234, "The Beautiful Letdown", 100, New DateTime(2008, 3, 3, 1, 46, 0)))
        songs.Add(New Song("This Is Your Life", "Switchfoot", 401234, "The Beautiful Letdown", 100, New DateTime(2008, 3, 3, 2, 11, 0)))
        songs.Add(New Song("More than fine", "Switchfoot", 4901234, "The Beautiful Letdown", 60, New DateTime(2008, 3, 3, 2, 16, 0)))
        songs.Add(New Song("Ammunition", "Switchfoot", 4401234, "The Beautiful Letdown", 40, New DateTime(2008, 3, 3, 1, 58, 0)))
        songs.Add(New Song("Dare you to move", "Switchfoot", 4901234, "The Beautiful Letdown", 80, New DateTime(2008, 3, 3, 2, 20, 0)))
        songs.Add(New Song("Redemption", "Switchfoot", 3601234, "The Beautiful Letdown", 80, New DateTime(2008, 3, 19, 5, 19, 0)))
        songs.Add(New Song("The beautiful letdown", "Switchfoot", 6201234, "The Beautiful Letdown", 60, New DateTime(2008, 3, 3, 2, 29, 0)))
        songs.Add(New Song("Gone", "Switchfoot", 4401234, "The Beautiful Letdown", 80, New DateTime(2008, 3, 3, 2, 33, 0)))
        songs.Add(New Song("On Fire", "Switchfoot", 4301234, "The Beautiful Letdown", 80, New DateTime(2008, 3, 3, 2, 37, 0)))
        songs.Add(New Song("Adding to the noise", "Switchfoot", 3301234, "The Beautiful Letdown", 60, New DateTime(2008, 3, 19, 5, 42, 0)))
        songs.Add(New Song("Twenty-four", "Switchfoot", 5701234, "The Beautiful Letdown", 60, New DateTime(2008, 3, 3, 2, 45, 0)))
        songs.Add(New Song("Gap That Opened", "Boom Crash Opera", 4701234, "Boom Crash Opera", 40, New DateTime(2008, 1, 13, 10, 11, 0)))
        songs.Add(New Song("Hands Up In The Air", "Boom Crash Opera", 4501234, "Boom Crash Opera", 80, New DateTime(2008, 3, 24, 3, 19, 0)))
        songs.Add(New Song("Love Me To Death", "Boom Crash Opera", 5201234, "Boom Crash Opera", 40, New DateTime(2008, 1, 13, 10, 20, 0)))
        songs.Add(New Song("City Fist", "Boom Crash Opera", 4901234, "Boom Crash Opera", 40, New DateTime(2008, 1, 13, 10, 24, 0)))
        songs.Add(New Song("Her Charity", "Boom Crash Opera", 5801234, "Boom Crash Opera", 40, New DateTime(2008, 1, 13, 10, 29, 0)))
        songs.Add(New Song("Sleeping Time", "Boom Crash Opera", 5201234, "Boom Crash Opera", 40, New DateTime(2008, 1, 13, 10, 33, 0)))
        songs.Add(New Song("Great Wall", "Boom Crash Opera", 4501234, "Boom Crash Opera", 80, New DateTime(2008, 3, 24, 3, 22, 0)))
        songs.Add(New Song("Bombshell", "Boom Crash Opera", 4501234, "Boom Crash Opera", 40, New DateTime(2008, 1, 13, 10, 41, 0)))
        songs.Add(New Song("Caught Between Two Towns", "Boom Crash Opera", 401234, "Boom Crash Opera", 40, New DateTime(2008, 1, 13, 10, 44, 0)))
        songs.Add(New Song("Too Hot To Think", "Boom Crash Opera", 6301234, "Boom Crash Opera", 40, New DateTime(2008, 1, 13, 10, 50, 0)))
        songs.Add(New Song("Starting Today", "Natalie Imbruglia", 6801234, "Counting Down the Days", 0, New DateTime(2008, 3, 19, 9, 48, 0)))
        songs.Add(New Song("Shiver", "Natalie Imbruglia", 8601234, "Counting Down the Days", 80, New DateTime(2008, 3, 19, 9, 51, 0)))
        songs.Add(New Song("Satisfied", "Natalie Imbruglia", 8101234, "Counting Down the Days", 0, New DateTime(2008, 3, 19, 9, 55, 0)))
        songs.Add(New Song("Counting Down the Days", "Natalie Imbruglia", 9601234, "Counting Down the Days", 60, New DateTime(2008, 3, 26, 10, 33, 0)))
        songs.Add(New Song("I Won't Be Lost", "Natalie Imbruglia", 901234, "Counting Down the Days", 60, New DateTime(2008, 3, 26, 10, 37, 0)))
        songs.Add(New Song("Slow Down", "Natalie Imbruglia", 8101234, "Counting Down the Days", 60, New DateTime(2008, 3, 26, 10, 41, 0)))
        songs.Add(New Song("Sanctuary", "Natalie Imbruglia", 7301234, "Counting Down the Days", 60, New DateTime(2008, 3, 26, 10, 44, 0)))
        songs.Add(New Song("Perfectly", "Natalie Imbruglia", 7801234, "Counting Down the Days", 80, New DateTime(2008, 3, 26, 10, 47, 0)))
        songs.Add(New Song("On the Run", "Natalie Imbruglia", 8401234, "Counting Down the Days", 60, New DateTime(2008, 3, 26, 10, 51, 0)))
        songs.Add(New Song("Come on Home", "Natalie Imbruglia", 9101234, "Counting Down the Days", 60, New DateTime(2008, 3, 26, 10, 55, 0)))
        songs.Add(New Song("When You're Sleeping", "Natalie Imbruglia", 7201234, "Counting Down the Days", 60, New DateTime(2008, 3, 26, 10, 58, 0)))
        songs.Add(New Song("Honeycomb Child", "Natalie Imbruglia", 9801234, "Counting Down the Days", 0, New DateTime(2008, 3, 26, 11, 2, 0)))
        songs.Add(New Song("Last Living Souls", "Gorillaz", 4501234, "Demon Days", 80, New DateTime(2008, 1, 12, 9, 55, 0)))
        songs.Add(New Song("Kids With Guns", "Gorillaz", 5301234, "Demon Days", 80, New DateTime(2008, 3, 24, 12, 52, 0)))
        songs.Add(New Song("O Green World", "Gorillaz", 6301234, "Demon Days", 80, New DateTime(2008, 3, 24, 12, 45, 0)))
        songs.Add(New Song("Dirty Harry", "Gorillaz", 5201234, "Demon Days", 80, New DateTime(2008, 3, 24, 12, 48, 0)))
        songs.Add(New Song("Feel Good Inc.", "Gorillaz", 5401234, "Demon Days", 100, New DateTime(2008, 3, 24, 1, 7, 0)))
        songs.Add(New Song("El Manana", "Gorillaz", 5401234, "Demon Days", 40, New DateTime(2008, 3, 17, 5, 45, 0)))
        songs.Add(New Song("Every Plant We Reach Is Dead", "Gorillaz", 6801234, "Demon Days", 80, New DateTime(2008, 3, 24, 12, 57, 0)))
        songs.Add(New Song("November Has Come", "Gorillaz", 3801234, "Demon Days", 80, New DateTime(2008, 3, 24, 12, 59, 0)))
        songs.Add(New Song("All Alone", "Gorillaz", 4901234, "Demon Days", 80, New DateTime(2008, 1, 12, 9, 49, 0)))
        songs.Add(New Song("White Light", "Gorillaz", 301234, "Demon Days", 80, New DateTime(2008, 2, 17, 3, 30, 0)))
        songs.Add(New Song("DARE", "Gorillaz", 5701234, "Demon Days", 80, New DateTime(2008, 3, 24, 1, 3, 0)))
        songs.Add(New Song("Don't Get Lost In Heaven", "Gorillaz", 2901234, "Demon Days", 80, New DateTime(2008, 3, 24, 12, 36, 0)))
        songs.Add(New Song("Demon Days", "Gorillaz", 6301234, "Demon Days", 80, New DateTime(2008, 3, 24, 12, 40, 0)))
        songs.Add(New Song("The Pretender", "Foo Fighters", 8301234, "Echoes, Silence, Patience & Grace", 60, New DateTime(2008, 3, 24, 11, 20, 0)))
        songs.Add(New Song("Let It Die", "Foo Fighters", 7601234, "Echoes, Silence, Patience & Grace", 40, New DateTime(2008, 3, 24, 11, 24, 0)))
        songs.Add(New Song("Erase/Replace", "Foo Fighters", 7801234, "Echoes, Silence, Patience & Grace", 60, New DateTime(2008, 3, 24, 11, 28, 0)))
        songs.Add(New Song("Long Road To Ruin", "Foo Fighters", 701234, "Echoes, Silence, Patience & Grace", 60, New DateTime(2008, 3, 24, 11, 31, 0)))
        songs.Add(New Song("Come Alive", "Foo Fighters", 9601234, "Echoes, Silence, Patience & Grace", 60, New DateTime(2008, 3, 24, 11, 37, 0)))
        songs.Add(New Song("Stranger Things Have Happened", "Foo Fighters", 9901234, "Echoes, Silence, Patience & Grace", 80, New DateTime(2008, 3, 24, 11, 42, 0)))
        songs.Add(New Song("Cheer Up, Boys (Your Makeup Is Running)", "Foo Fighters", 6801234, "Echoes, Silence, Patience & Grace", 40, New DateTime(2008, 3, 24, 11, 45, 0)))
        songs.Add(New Song("Summer's End", "Foo Fighters", 8601234, "Echoes, Silence, Patience & Grace", 60, New DateTime(2008, 3, 24, 11, 50, 0)))
        songs.Add(New Song("The Ballad Of The Beaconsfield", "Foo Fighters", 4701234, "Echoes, Silence, Patience & Grace", 80, New DateTime(2008, 3, 24, 11, 53, 0)))
        songs.Add(New Song("Statues", "Foo Fighters", 701234, "Echoes, Silence, Patience & Grace", 60, New DateTime(2008, 3, 24, 11, 57, 0)))
        songs.Add(New Song("But, Honestly", "Foo Fighters", 8501234, "Echoes, Silence, Patience & Grace", 40, New DateTime(2008, 3, 24, 12, 1, 0)))
        songs.Add(New Song("Home", "Foo Fighters", 901234, "Echoes, Silence, Patience & Grace", 80, New DateTime(2008, 3, 24, 12, 6, 0)))
        songs.Add(New Song("Once And For All (Demo) (Bonus Song)", "Foo Fighters", 701234, "Echoes, Silence, Patience & Grace", 0, New DateTime(2008, 3, 24, 12, 10, 0)))
        songs.Add(New Song("Going Under", "Evanescence", 4201234, "Fallen", 0, New DateTime(2008, 2, 4, 6, 9, 0)))
        songs.Add(New Song("Bring Me To Life", "Evanescence", 4601234, "Fallen", 100, New DateTime(2008, 3, 25, 12, 56, 0)))
        songs.Add(New Song("Everybody's Fool", "Evanescence", 3801234, "Fallen", 0, New DateTime(2008, 2, 4, 6, 16, 0)))
        songs.Add(New Song("Haunted", "Evanescence", 3601234, "Fallen", 0, New DateTime(2008, 2, 4, 6, 19, 0)))
        songs.Add(New Song("Tourniquet", "Evanescence", 5401234, "Fallen", 0, New DateTime(2008, 2, 4, 6, 24, 0)))
        songs.Add(New Song("Imaginary", "Evanescence", 501234, "Fallen", 0, New DateTime(2008, 2, 4, 6, 28, 0)))
        songs.Add(New Song("Taking Over Me", "Evanescence", 4401234, "Fallen", 0, New DateTime(2008, 3, 15, 4, 57, 0)))
        songs.Add(New Song("Hello", "Evanescence", 4301234, "Fallen", 0, New DateTime(2008, 2, 4, 6, 35, 0)))
        songs.Add(New Song("My Last Breath", "Evanescence", 4801234, "Fallen", 0, New DateTime(2008, 3, 15, 4, 23, 0)))
        songs.Add(New Song("Whisper", "Evanescence", 6301234, "Fallen", 0, New DateTime(2008, 2, 4, 6, 45, 0)))
        songs.Add(New Song("My Immortal", "Evanescence", 5301234, "Fallen", 0, New DateTime(2008, 2, 4, 6, 50, 0)))
        songs.Add(New Song("One-Trick Pony", "Nelly Furtado", 501234, "Folklore", 80, New DateTime(2008, 3, 15, 6, 46, 0)))
        songs.Add(New Song("Powerless (Say What You Want)", "Nelly Furtado", 4201234, "Folklore", 80, New DateTime(2008, 3, 15, 6, 50, 0)))
        songs.Add(New Song("Explode", "Nelly Furtado", 4101234, "Folklore", 80, New DateTime(2008, 3, 15, 6, 53, 0)))
        songs.Add(New Song("Try", "Nelly Furtado", 4901234, "Folklore", 80, New DateTime(2008, 3, 15, 11, 49, 0)))
        songs.Add(New Song("Fresh off the Boat", "Nelly Furtado", 3701234, "Folklore", 60, New DateTime(2008, 2, 22, 12, 49, 0)))
        songs.Add(New Song("Força", "Nelly Furtado", 401234, "Folklore", 40, New DateTime(2008, 2, 22, 12, 53, 0)))
        songs.Add(New Song("The Grass Is Green", "Nelly Furtado", 4201234, "Folklore", 40, New DateTime(2008, 2, 22, 12, 57, 0)))
        songs.Add(New Song("Picture Perfect", "Nelly Furtado", 5501234, "Folklore", 40, New DateTime(2008, 1, 19, 12, 8, 0)))
        songs.Add(New Song("Saturdays", "Jarvis Church/Nelly Furtado", 2601234, "Folklore", 40, New DateTime(2008, 1, 7, 7, 33, 0)))
        songs.Add(New Song("Build You Up", "Nelly Furtado", 5201234, "Folklore", 40, New DateTime(2008, 2, 22, 1, 3, 0)))
        songs.Add(New Song("Island of Wonder", "Caetano Veloso/Nelly Furtado", 4201234, "Folklore", 40, New DateTime(2008, 1, 7, 7, 42, 0)))
        songs.Add(New Song("The Boy In The Bubble", "Paul Simon", 5601234, "Graceland", 60, New DateTime(2008, 1, 24, 6, 2, 0)))
        songs.Add(New Song("Graceland", "Paul Simon", 6701234, "Graceland", 60, New DateTime(2008, 1, 24, 6, 7, 0)))
        songs.Add(New Song("I Know What I Know", "Paul Simon", 4501234, "Graceland", 60, New DateTime(2008, 1, 22, 5, 27, 0)))
        songs.Add(New Song("Gumboots", "Paul Simon", 3901234, "Graceland", 60, New DateTime(2008, 1, 22, 5, 30, 0)))
        songs.Add(New Song("Diamonds On The Soles Of Her Shoes", "Paul Simon", 8101234, "Graceland", 80, New DateTime(2008, 2, 20, 9, 44, 0)))
        songs.Add(New Song("You Can Call Me Al", "Paul Simon", 6501234, "Graceland", 60, New DateTime(2008, 1, 22, 5, 40, 0)))
        songs.Add(New Song("Under African Skies", "Paul Simon", 5101234, "Graceland", 60, New DateTime(2008, 3, 19, 5, 27, 0)))
        songs.Add(New Song("Homeless", "Paul Simon", 5301234, "Graceland", 60, New DateTime(2007, 11, 23, 7, 1, 0)))
        songs.Add(New Song("Crazy Love Vol II", "Paul Simon", 601234, "Graceland", 60, New DateTime(2008, 1, 22, 5, 44, 0)))
        songs.Add(New Song("That Was Your Mother", "Paul Simon", 4101234, "Graceland", 60, New DateTime(2008, 1, 22, 5, 47, 0)))
        songs.Add(New Song("All Around The World Or The Myth of Fingerprints", "Paul Simon", 4601234, "Graceland", 60, New DateTime(2008, 3, 19, 5, 31, 0)))
        songs.Add(New Song("Vertigo", "U2", 3801234, "How To Dismantle An Atomic Bomb", 100, New DateTime(2007, 12, 18, 12, 11, 0)))
        songs.Add(New Song("Miracle Drug", "U2", 4701234, "How To Dismantle An Atomic Bomb", 100, New DateTime(2008, 3, 19, 12, 4, 0)))
        songs.Add(New Song("Sometimes You Can't Make It On Your Own", "U2", 601234, "How To Dismantle An Atomic Bomb", 60, New DateTime(2007, 12, 18, 12, 20, 0)))
        songs.Add(New Song("Love And Peace Or Else", "U2", 5601234, "How To Dismantle An Atomic Bomb", 60, New DateTime(2008, 3, 15, 4, 16, 0)))
        songs.Add(New Song("City Of Blinding Lights", "U2", 6701234, "How To Dismantle An Atomic Bomb", 80, New DateTime(2008, 3, 19, 12, 10, 0)))
        songs.Add(New Song("All Because Of You", "U2", 4301234, "How To Dismantle An Atomic Bomb", 60, New DateTime(2007, 11, 6, 11, 2, 0)))
        songs.Add(New Song("A Man And A Woman", "U2", 5301234, "How To Dismantle An Atomic Bomb", 100, New DateTime(2008, 3, 19, 12, 0, 0)))
        songs.Add(New Song("Crumbs From Your Table", "U2", 5901234, "How To Dismantle An Atomic Bomb", 60, New DateTime(2007, 11, 6, 11, 12, 0)))
        songs.Add(New Song("One Step Closer", "U2", 4501234, "How To Dismantle An Atomic Bomb", 40, New DateTime(2007, 11, 6, 11, 16, 0)))
        songs.Add(New Song("Original Of The Species", "U2", 5501234, "How To Dismantle An Atomic Bomb", 40, New DateTime(2007, 11, 6, 11, 20, 0)))
        songs.Add(New Song("Yahweh", "U2", 5101234, "How To Dismantle An Atomic Bomb", 80, New DateTime(2008, 3, 18, 11, 56, 0)))
        songs.Add(New Song("Grim Travellers", "Bruce Cockburn", 5601234, "Humans", 60, New DateTime(2008, 3, 15, 4, 31, 0)))
        songs.Add(New Song("Rumours Of Glory", "Bruce Cockburn", 4301234, "Humans", 80, New DateTime(2008, 3, 25, 1, 25, 0)))
        songs.Add(New Song("More Not More", "Bruce Cockburn", 4401234, "Humans", 60, New DateTime(2007, 10, 27, 7, 47, 0)))
        songs.Add(New Song("You Get Bigger As You Go", "Bruce Cockburn", 5301234, "Humans", 40, New DateTime(2007, 10, 27, 7, 51, 0)))
        songs.Add(New Song("What About The Bond", "Bruce Cockburn", 5701234, "Humans", 40, New DateTime(2007, 10, 27, 7, 56, 0)))
        songs.Add(New Song("How I Spent My Fall Vacation", "Bruce Cockburn", 5901234, "Humans", 60, New DateTime(2007, 10, 27, 8, 1, 0)))
        songs.Add(New Song("Guerilla Betrayed", "Bruce Cockburn", 4601234, "Humans", 60, New DateTime(2007, 10, 27, 8, 5, 0)))
        songs.Add(New Song("Tokyo", "Bruce Cockburn", 4101234, "Humans", 60, New DateTime(2007, 10, 27, 8, 9, 0)))
        songs.Add(New Song("Fascist Architecture", "Bruce Cockburn", 3101234, "Humans", 60, New DateTime(2007, 11, 15, 3, 40, 0)))
        songs.Add(New Song("The Rose Above The Sky", "Bruce Cockburn", 7401234, "Humans", 80, New DateTime(2008, 3, 25, 1, 22, 0)))
        songs.Add(New Song("Torn", "Natalie Imbruglia", 5601234, "Left Of The Middle", 100, New DateTime(2008, 3, 26, 11, 6, 0)))
        songs.Add(New Song("One More Addiction", "Natalie Imbruglia", 4901234, "Left Of The Middle", 60, New DateTime(2008, 3, 26, 11, 9, 0)))
        songs.Add(New Song("Big Mistake", "Natalie Imbruglia", 6301234, "Left Of The Middle", 80, New DateTime(2008, 3, 26, 11, 14, 0)))
        songs.Add(New Song("Leave Me Alone", "Natalie Imbruglia", 601234, "Left Of The Middle", 60, New DateTime(2008, 3, 26, 11, 18, 0)))
        songs.Add(New Song("Wishing I Was There", "Natalie Imbruglia", 5301234, "Left Of The Middle", 80, New DateTime(2008, 3, 26, 11, 22, 0)))
        songs.Add(New Song("Smoke", "Natalie Imbruglia", 6401234, "Left Of The Middle", 60, New DateTime(2008, 3, 26, 11, 26, 0)))
        songs.Add(New Song("Pigeons And Crumbs", "Natalie Imbruglia", 7401234, "Left Of The Middle", 0, New DateTime(2008, 3, 26, 11, 32, 0)))
        songs.Add(New Song("Don't You Think", "Natalie Imbruglia", 5401234, "Left Of The Middle", 80, New DateTime(2008, 3, 26, 11, 36, 0)))
        songs.Add(New Song("Impressed", "Natalie Imbruglia", 6601234, "Left Of The Middle", 80, New DateTime(2008, 3, 26, 11, 40, 0)))
        songs.Add(New Song("Intuition", "Natalie Imbruglia", 4701234, "Left Of The Middle", 80, New DateTime(2008, 3, 26, 11, 44, 0)))
        songs.Add(New Song("City", "Natalie Imbruglia", 6301234, "Left Of The Middle", 0, New DateTime(2008, 3, 26, 11, 48, 0)))
        songs.Add(New Song("Left Of The Middle", "Natalie Imbruglia", 5201234, "Left Of The Middle", 60, New DateTime(2008, 3, 26, 11, 52, 0)))
        songs.Add(New Song("Life For Rent", "Dido", 4301234, "Life For Rent", 80, New DateTime(2008, 2, 20, 9, 35, 0)))
        songs.Add(New Song("Mary's In India", "Dido", 4301234, "Life For Rent", 80, New DateTime(2008, 2, 20, 9, 39, 0)))
        songs.Add(New Song("See You When You're 40", "Dido", 6201234, "Life For Rent", 80, New DateTime(2008, 2, 20, 9, 15, 0)))
        songs.Add(New Song("Don't Leave Home", "Dido", 4401234, "Life For Rent", 80, New DateTime(2008, 2, 20, 9, 31, 0)))
        songs.Add(New Song("Who Makes You Feel", "Dido", 5101234, "Life For Rent", 80, New DateTime(2008, 2, 20, 9, 9, 0)))
        songs.Add(New Song("Sand In My Shoes", "Dido", 5801234, "Life For Rent", 80, New DateTime(2008, 2, 20, 9, 24, 0)))
        songs.Add(New Song("Do You Have A Little Time", "Dido", 4601234, "Life For Rent", 80, New DateTime(2008, 2, 20, 9, 19, 0)))
        songs.Add(New Song("This Land Is Mine", "Dido", 4401234, "Life For Rent", 80, New DateTime(2008, 2, 20, 9, 27, 0)))
        songs.Add(New Song("See The Sun", "Dido", 10123422, "Life For Rent", 60, New DateTime(2007, 12, 22, 10, 28, 0)))
        songs.Add(New Song("Lifesong", "Casting Crowns", 4901234, "Lifesong", 80, New DateTime(2008, 3, 24, 2, 36, 0)))
        songs.Add(New Song("Praise You in This Storm", "Casting Crowns", 4601234, "Lifesong", 100, New DateTime(2008, 3, 24, 2, 17, 0)))
        songs.Add(New Song("Does Anybody Hear Her", "Casting Crowns", 4201234, "Lifesong", 60, New DateTime(2007, 12, 26, 3, 7, 0)))
        songs.Add(New Song("Stained Glass Masquerade", "Casting Crowns", 3601234, "Lifesong", 60, New DateTime(2007, 12, 26, 3, 11, 0)))
        songs.Add(New Song("Love Them Like Jesus", "Casting Crowns", 4201234, "Lifesong", 60, New DateTime(2007, 11, 4, 3, 0, 0)))
        songs.Add(New Song("Set Me Free", "Casting Crowns", 4101234, "Lifesong", 80, New DateTime(2008, 3, 24, 2, 12, 0)))
        songs.Add(New Song("While You Were Sleeping", "Casting Crowns", 4501234, "Lifesong", 60, New DateTime(2008, 1, 1, 12, 39, 0)))
        songs.Add(New Song("Father, Spirit, Jesus", "Casting Crowns", 4801234, "Lifesong", 80, New DateTime(2008, 3, 24, 2, 41, 0)))
        songs.Add(New Song("In Me", "Casting Crowns", 4401234, "Lifesong", 80, New DateTime(2008, 3, 24, 2, 31, 0)))
        songs.Add(New Song("Prodigal", "Casting Crowns", 5301234, "Lifesong", 60, New DateTime(2007, 12, 26, 3, 36, 0)))
        songs.Add(New Song("And Now My Lifesong Sings", "Casting Crowns", 3801234, "Lifesong", 60, New DateTime(2008, 1, 1, 12, 54, 0)))
        songs.Add(New Song("Afraid", "Nelly Furtado", 3301234, "Loose", 80, New DateTime(2008, 3, 15, 11, 41, 0)))
        songs.Add(New Song("Maneater", "Nelly Furtado", 4101234, "Loose", 40, New DateTime(2008, 1, 19, 12, 20, 0)))
        songs.Add(New Song("Promiscuous", "Nelly Furtado", 3701234, "Loose", 60, New DateTime(2008, 1, 21, 5, 1, 0)))
        songs.Add(New Song("Glow", "Nelly Furtado", 3701234, "Loose", 80, New DateTime(2008, 3, 15, 11, 45, 0)))
        songs.Add(New Song("Showtime", "Nelly Furtado", 3901234, "Loose", 80, New DateTime(2008, 3, 15, 6, 37, 0)))
        songs.Add(New Song("No Hay Igual", "Nelly Furtado", 3301234, "Loose", 80, New DateTime(2008, 3, 15, 11, 33, 0)))
        songs.Add(New Song("Te Busque", "Nelly Furtado", 3401234, "Loose", 60, New DateTime(2008, 1, 21, 5, 17, 0)))
        songs.Add(New Song("Say It Right", "Nelly Furtado", 3401234, "Loose", 60, New DateTime(2008, 1, 21, 5, 21, 0)))
        songs.Add(New Song("Do It", "Nelly Furtado", 3401234, "Loose", 60, New DateTime(2008, 1, 21, 5, 24, 0)))
        songs.Add(New Song("In God's Hands", "Nelly Furtado", 4501234, "Loose", 40, New DateTime(2008, 1, 21, 5, 29, 0)))
        songs.Add(New Song("Wait for You", "Nelly Furtado", 4801234, "Loose", 40, New DateTime(2008, 1, 21, 5, 34, 0)))
        songs.Add(New Song("Somebody to Love", "Nelly Furtado", 4601234, "Loose", 40, New DateTime(2008, 1, 21, 5, 39, 0)))
        songs.Add(New Song("All Good Things (Come to an End)", "Nelly Furtado", 4801234, "Loose", 40, New DateTime(2008, 1, 21, 5, 44, 0)))
        songs.Add(New Song("Someone Somewhere In Summertime", "Simple Minds", 6501234, "New Gold Gream (81/82/83/84)", 60, New DateTime(2007, 9, 1, 9, 11, 0)))
        songs.Add(New Song("Colours Fly And Catherine Wheel", "Simple Minds", 5401234, "New Gold Gream (81/82/83/84)", 80, New DateTime(2007, 11, 19, 8, 34, 0)))
        songs.Add(New Song("Big Sleep", "Simple Minds", 6901234, "New Gold Gream (81/82/83/84)", 40, New DateTime(2007, 9, 1, 9, 20, 0)))
        songs.Add(New Song("Somebody Up There Likes You", "Simple Minds", 701234, "New Gold Gream (81/82/83/84)", 40, New DateTime(2007, 9, 1, 9, 25, 0)))
        songs.Add(New Song("New Gold Dream (81-82-83-84)", "Simple Minds", 7901234, "New Gold Gream (81/82/83/84)", 60, New DateTime(2007, 9, 1, 9, 30, 0)))
        songs.Add(New Song("Glittering Prize", "Simple Minds", 6401234, "New Gold Gream (81/82/83/84)", 60, New DateTime(2007, 8, 13, 8, 24, 0)))
        songs.Add(New Song("Hunter And The Hunted", "Simple Minds", 8301234, "New Gold Gream (81/82/83/84)", 60, New DateTime(2007, 8, 13, 8, 30, 0)))
        songs.Add(New Song("King Is White And In The Crowd", "Simple Minds", 9701234, "New Gold Gream (81/82/83/84)", 20, New DateTime(2007, 8, 13, 8, 37, 0)))
        songs.Add(New Song("Promised you a miracle", "Simple Minds", 4701234, "New Gold Gream (81/82/83/84)", 40, New DateTime(2008, 1, 10, 12, 1, 0)))
        songs.Add(New Song("Psycho Killer", "Talking Heads", 5201234, "Once In A Lifetime", 40, New DateTime(2008, 2, 4, 5, 6, 0)))
        songs.Add(New Song("Take Me To The River", "Talking Heads", 601234, "Once In A Lifetime", 40, New DateTime(2008, 2, 4, 5, 11, 0)))
        songs.Add(New Song("Once In A Lifetime", "Talking Heads", 5201234, "Once In A Lifetime", 80, New DateTime(2008, 2, 4, 5, 15, 0)))
        songs.Add(New Song("Burning Down The House", "Talking Heads", 4801234, "Once In A Lifetime", 100, New DateTime(2008, 2, 10, 12, 19, 0)))
        songs.Add(New Song("This Must Be The Place (Naive Melody)", "Talking Heads", 5901234, "Once In A Lifetime", 40, New DateTime(2008, 2, 4, 5, 24, 0)))
        songs.Add(New Song("Slippery People (Live)", "Talking Heads", 5101234, "Once In A Lifetime", 40, New DateTime(2008, 2, 4, 5, 28, 0)))
        songs.Add(New Song("Life During Wartime (Live)", "Talking Heads", 601234, "Once In A Lifetime", 40, New DateTime(2008, 2, 4, 5, 34, 0)))
        songs.Add(New Song("And She Was", "Talking Heads", 4401234, "Once In A Lifetime", 60, New DateTime(2008, 2, 4, 5, 37, 0)))
        songs.Add(New Song("Road To Nowhere", "Talking Heads", 5201234, "Once In A Lifetime", 80, New DateTime(2008, 2, 4, 5, 42, 0)))
        songs.Add(New Song("Wild Wild Life", "Talking Heads", 4401234, "Once In A Lifetime", 60, New DateTime(2008, 2, 4, 5, 45, 0)))
        songs.Add(New Song("Blind", "Talking Heads", 5901234, "Once In A Lifetime", 40, New DateTime(2008, 2, 4, 5, 50, 0)))
        songs.Add(New Song("(Nothing But) Flowers", "Talking Heads", 6601234, "Once In A Lifetime", 40, New DateTime(2008, 2, 4, 5, 56, 0)))
        songs.Add(New Song("Sax And Violins", "Talking Heads", 6301234, "Once In A Lifetime", 60, New DateTime(2008, 2, 4, 6, 1, 0)))
        songs.Add(New Song("Lifetime Piling Up", "Talking Heads", 4601234, "Once In A Lifetime", 80, New DateTime(2008, 2, 4, 6, 5, 0)))
        songs.Add(New Song("Honey", "Moby", 4801234, "Play", 80, New DateTime(2008, 2, 22, 10, 59, 0)))
        songs.Add(New Song("Find My Baby", "Moby", 5501234, "Play", 60, New DateTime(2008, 2, 22, 11, 3, 0)))
        songs.Add(New Song("Porcelain", "Moby", 5601234, "Play", 40, New DateTime(2008, 3, 14, 11, 34, 0)))
        songs.Add(New Song("Why Does My Heart Feel So Bad?", "Moby", 6101234, "Play", 80, New DateTime(2008, 2, 22, 11, 12, 0)))
        songs.Add(New Song("Southside", "Moby", 5301234, "Play", 80, New DateTime(2008, 3, 3, 4, 20, 0)))
        songs.Add(New Song("Rushing", "Moby", 4201234, "Play", 60, New DateTime(2008, 3, 14, 11, 30, 0)))
        songs.Add(New Song("Bodyrock", "Moby", 501234, "Play", 100, New DateTime(2008, 3, 14, 11, 27, 0)))
        songs.Add(New Song("Natural Blues", "Moby", 5901234, "Play", 40, New DateTime(2008, 2, 22, 11, 27, 0)))
        songs.Add(New Song("Machete", "Moby", 5101234, "Play", 20, New DateTime(2008, 2, 22, 11, 30, 0)))
        songs.Add(New Song("7", "Moby", 1501234, "Play", 20, New DateTime(2008, 3, 14, 11, 23, 0)))
        songs.Add(New Song("Run On", "Moby", 5201234, "Play", 40, New DateTime(2008, 3, 19, 5, 52, 0)))
        songs.Add(New Song("Down Slow", "Moby", 2201234, "Play", 40, New DateTime(2008, 3, 14, 11, 22, 0)))
        songs.Add(New Song("If Things Were Perfect", "Moby", 601234, "Play", 60, New DateTime(2008, 2, 22, 11, 40, 0)))
        songs.Add(New Song("Everloving", "Moby", 4801234, "Play", 40, New DateTime(2007, 12, 27, 11, 6, 0)))
        songs.Add(New Song("Inside", "Moby", 6701234, "Play", 60, New DateTime(2007, 12, 27, 11, 10, 0)))
        songs.Add(New Song("Guitar Flute And String", "Moby", 301234, "Play", 60, New DateTime(2007, 12, 27, 11, 12, 0)))
        songs.Add(New Song("The Sky Is Broken", "Moby", 601234, "Play", 60, New DateTime(2007, 11, 4, 2, 22, 0)))
        songs.Add(New Song("My Weakness", "Moby", 501234, "Play", 40, New DateTime(2007, 11, 4, 2, 26, 0)))
        songs.Add(New Song("Discotheque", "U2", 6101234, "Pop", 100, New DateTime(2008, 3, 3, 4, 16, 0)))
        songs.Add(New Song("Do You Feel Loved", "U2", 5901234, "Pop", 60, New DateTime(2008, 2, 7, 11, 4, 0)))
        songs.Add(New Song("Mofo", "U2", 6701234, "Pop", 60, New DateTime(2008, 2, 7, 11, 10, 0)))
        songs.Add(New Song("If God Will Send His Angels", "U2", 6201234, "Pop", 80, New DateTime(2008, 2, 7, 11, 16, 0)))
        songs.Add(New Song("Staring At The Sun", "U2", 5301234, "Pop", 80, New DateTime(2008, 3, 19, 12, 15, 0)))
        songs.Add(New Song("Last Night On Earth", "U2", 5501234, "Pop", 100, New DateTime(2008, 2, 7, 11, 25, 0)))
        songs.Add(New Song("Gone", "U2", 5101234, "Pop", 60, New DateTime(2008, 2, 7, 11, 29, 0)))
        songs.Add(New Song("Miami", "U2", 5601234, "Pop", 40, New DateTime(2007, 11, 14, 5, 53, 0)))
        songs.Add(New Song("The Playboy Mansion", "U2", 5401234, "Pop", 40, New DateTime(2007, 11, 14, 5, 58, 0)))
        songs.Add(New Song("If You Wear That Velvet Dress", "U2", 6101234, "Pop", 60, New DateTime(2007, 11, 14, 6, 3, 0)))
        songs.Add(New Song("Please", "U2", 5801234, "Pop", 40, New DateTime(2008, 2, 6, 11, 28, 0)))
        songs.Add(New Song("Wake Up Dead Man", "U2", 5601234, "Pop", 40, New DateTime(2008, 2, 6, 11, 20, 0)))
        songs.Add(New Song("The River", "Live", 4101234, "Songs From Black Mountain", 80, New DateTime(2008, 3, 24, 10, 55, 0)))
        songs.Add(New Song("Mystery", "Live", 5201234, "Songs From Black Mountain", 80, New DateTime(2008, 3, 24, 10, 59, 0)))
        songs.Add(New Song("Get Ready", "Live", 4901234, "Songs From Black Mountain", 60, New DateTime(2008, 3, 23, 1, 2, 0)))
        songs.Add(New Song("Show", "Live", 4701234, "Songs From Black Mountain", 80, New DateTime(2008, 3, 24, 11, 3, 0)))
        songs.Add(New Song("Wings", "Live", 5301234, "Songs From Black Mountain", 0, New DateTime(2008, 3, 23, 1, 9, 0)))
        songs.Add(New Song("Sofia", "Live", 5401234, "Songs From Black Mountain", 0, New DateTime(2008, 3, 23, 1, 13, 0)))
        songs.Add(New Song("Love Shines (A Song For My Daughters About God)", "Live", 4601234, "Songs From Black Mountain", 0, New DateTime(2008, 3, 23, 1, 16, 0)))
        songs.Add(New Song("Where Do We Go From Here", "Live", 5201234, "Songs From Black Mountain", 0, New DateTime(2008, 3, 23, 1, 20, 0)))
        songs.Add(New Song("Home", "Live", 4701234, "Songs From Black Mountain", 0, New DateTime(2008, 3, 23, 1, 23, 0)))
        songs.Add(New Song("All I Need", "Live", 4501234, "Songs From Black Mountain", 0, New DateTime(2008, 3, 23, 1, 26, 0)))
        songs.Add(New Song("You Are Not Alone", "Live", 5201234, "Songs From Black Mountain", 0, New DateTime(2008, 2, 19, 12, 5, 0)))
        songs.Add(New Song("Night Of Nights", "Live", 4901234, "Songs From Black Mountain", 0, New DateTime(2008, 2, 19, 12, 8, 0)))
        songs.Add(New Song("All For Believing", "Missy Higgins", 4201234, "The Sound Of White", 80, New DateTime(2008, 1, 30, 4, 21, 0)))
        songs.Add(New Song("Don't Ever", "Missy Higgins", 3501234, "The Sound Of White", 40, New DateTime(2008, 1, 30, 4, 24, 0)))
        songs.Add(New Song("Scar", "Missy Higgins", 4301234, "The Sound Of White", 80, New DateTime(2008, 1, 30, 4, 28, 0)))
        songs.Add(New Song("Ten Days", "Missy Higgins", 4501234, "The Sound Of White", 80, New DateTime(2008, 1, 30, 5, 10, 0)))
        songs.Add(New Song("Nightminds", "Missy Higgins", 401234, "The Sound Of White", 60, New DateTime(2008, 1, 30, 5, 13, 0)))
        songs.Add(New Song("Casualty", "Missy Higgins", 501234, "The Sound Of White", 60, New DateTime(2008, 3, 15, 4, 43, 0)))
        songs.Add(New Song("Any Day Now", "Missy Higgins", 4601234, "The Sound Of White", 60, New DateTime(2007, 12, 30, 2, 35, 0)))
        songs.Add(New Song("Katie", "Missy Higgins", 4301234, "The Sound Of White", 60, New DateTime(2007, 12, 30, 2, 38, 0)))
        songs.Add(New Song("The River", "Missy Higgins", 5301234, "The Sound Of White", 60, New DateTime(2007, 11, 16, 9, 6, 0)))
        songs.Add(New Song("The Special Two", "Missy Higgins", 5201234, "The Sound Of White", 100, New DateTime(2008, 1, 30, 5, 18, 0)))
        songs.Add(New Song("This Is How It Goes", "Missy Higgins", 4201234, "The Sound Of White", 60, New DateTime(2008, 1, 30, 5, 22, 0)))
        songs.Add(New Song("The Sound Of White", "Missy Higgins", 5701234, "The Sound Of White", 80, New DateTime(2008, 1, 30, 5, 27, 0)))
        songs.Add(New Song("They Weren't There", "Missy Higgins", 4901234, "The Sound Of White", 60, New DateTime(2007, 12, 30, 2, 56, 0)))

        Return songs
    End Function
End Class

Public Class ArtistExample
    Public Sub New(name As String)
        Me.Title = name
    End Sub

    Public Property Title() As String
        Get
            Return m_title
        End Get
        Set(value As String)
            m_title = value
        End Set
    End Property
    Private m_title As String

    Public ReadOnly Property Albums() As List(Of AlbumExample)
        Get
            If Me.m_albums Is Nothing Then
                Me.m_albums = Song.GetAlbumsForArtist(Me.Title)
            End If
            Return Me.m_albums
        End Get
    End Property
    Private m_albums As List(Of AlbumExample)

    Public ReadOnly Property SizeInBytes() As Long
        Get
            If Me.m_sizeInBytes = -1 Then
                Me.m_sizeInBytes = 0
                For Each album As AlbumExample In Me.Albums
                    Me.m_sizeInBytes += album.SizeInBytes
                Next
            End If
            Return Me.m_sizeInBytes
        End Get
    End Property
    Private m_sizeInBytes As Long = -1

    Public ReadOnly Property LastPlayed() As DateTime
        Get
            If Me.m_lastPlayed = DateTime.MinValue Then
                For Each album As AlbumExample In Me.Albums
                    If album.LastPlayed > Me.m_lastPlayed Then
                        Me.m_lastPlayed = album.LastPlayed
                    End If
                Next
            End If
            Return Me.m_lastPlayed
        End Get
    End Property
    Private m_lastPlayed As DateTime = DateTime.MinValue

    Public ReadOnly Property Rating() As Integer
        Get
            If Me.m_rating = -1 Then
                Me.m_rating = 0
                For Each album As AlbumExample In Me.Albums
                    Me.m_rating += album.Rating
                Next
                If Me.Albums.Count > 0 Then
                    Me.m_rating /= Me.Albums.Count
                End If
            End If
            Return Me.m_rating
        End Get
    End Property
    Private m_rating As Integer = -1
End Class

Public Class AlbumExample
    Public Sub New(name As String)
        Me.Title = name
    End Sub

    Public Property Title() As String
        Get
            Return m_title
        End Get
        Set(value As String)
            m_title = value
        End Set
    End Property
    Private m_title As String

    Public ReadOnly Property Songs() As List(Of Song)
        Get
            If Me.m_songs Is Nothing Then
                Me.m_songs = Song.GetSongsForAlbum(Me.Title)
            End If
            Return Me.m_songs
        End Get
    End Property
    Private m_songs As List(Of Song)

    Public ReadOnly Property SizeInBytes() As Long
        Get
            If Me.m_sizeInBytes = -1 Then
                Me.m_sizeInBytes = 0
                For Each s As Song In Me.Songs
                    Me.m_sizeInBytes += s.SizeInBytes
                Next
            End If
            Return Me.m_sizeInBytes
        End Get
    End Property
    Private m_sizeInBytes As Long = -1

    Public ReadOnly Property LastPlayed() As DateTime
        Get
            If Me.m_lastPlayed = DateTime.MinValue Then
                For Each s As Song In Me.Songs
                    If s.LastPlayed > Me.m_lastPlayed Then
                        Me.m_lastPlayed = s.LastPlayed
                    End If
                Next
            End If
            Return Me.m_lastPlayed
        End Get
    End Property
    Private m_lastPlayed As DateTime = DateTime.MinValue

    Public ReadOnly Property Rating() As Integer
        Get
            If Me.m_rating = -1 Then
                Me.m_rating = 0
                For Each s As Song In Me.Songs
                    Me.m_rating += s.Rating
                Next
                If Me.Songs.Count > 0 Then
                    Me.m_rating /= Me.Songs.Count
                End If
            End If
            Return Me.m_rating
        End Get
    End Property
    Private m_rating As Integer = -1
End Class

