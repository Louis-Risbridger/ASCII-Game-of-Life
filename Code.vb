Imports System

Module Program
    Sub main()
        Dim run As New run
        Dim iterate As String
        Randomize()

        Console.WriteLine("Do you want to press to (i)terate or have it (a)utomatically cycle?")

        If LCase(Console.ReadLine()) = "i" Then

            Do
                run.start()
                iterate = Console.ReadLine
                Console.Clear()
            Loop Until iterate <> ""

        Else

            Do
                run.start()
                Threading.Thread.Sleep(100)
                Console.Clear()
            Loop
        End If

    End Sub

    Public Class Grid
        Dim height As Integer
        Dim width As Integer
        Dim screan(100, 100)
        Dim lastit(100, 100) As String



        Public Sub fillarray()
            For x = 0 To height
                For y = 0 To width
                    lastit(x, y) = getgrid(x, y)
                Next
            Next
        End Sub
        Public Sub generation()
            For x = 1 To height - 1
                For y = 1 To width - 1
                    If screan(x, y) = "0" Then
                        If getnear(x, y) < 2 Then
                            lastit(x, y) = " "
                        ElseIf getnear(x, y) = 2 Or getnear(x, y) = 3 Then
                            lastit(x, y) = "0"
                        ElseIf getnear(x, y) > 3 Then
                            lastit(x, y) = " "
                        End If
                    Else
                        If getnear(x, y) = 3 Then
                            lastit(x, y) = "0"
                        Else
                            lastit(x, y) = " "
                        End If
                    End If
                Next
            Next
        End Sub

        Public Sub display()
            For x = 0 To height
                For y = 0 To width
                    Console.Write(screan(x, y))
                Next
                Console.WriteLine()
            Next
        End Sub



        Public Function getgrid(ByRef height As Integer, ByRef width As Integer) As String
            Return screan(height, width)
        End Function
        Public Sub setHeight()
            Console.WriteLine("Please Input height of grid")
            height = Console.ReadLine()
        End Sub
        Public Sub setwidth()
            Console.WriteLine("Please input width")
            width = Console.ReadLine()
        End Sub

        Public Sub setScrean()

            Console.WriteLine("(R)andom or (s)et board")
            Dim answer As String
            answer = Console.ReadLine

            If LCase(answer) = "r" Then
                For x = 1 To height - 1
                    For y = 1 To width - 1
                        If Int((10 - 1 + 1) * Rnd() + 1) > 8 Then
                            screan(x, y) = "0"
                        Else
                            screan(x, y) = " "
                        End If
                    Next
                Next

                For x = 0 To width
                    screan(0, x) = "-"
                    screan(height, x) = "-"

                Next
                For x = 0 To height
                    screan(x, 0) = "-"
                    screan(x, width) = "-"
                Next
            Else
                screan(20, 40) = "0"
                screan(21, 38) = "0"
                screan(22, 40) = "0"
                screan(23, 38) = "0"
                screan(23, 39) = "0"
                screan(24, 38) = "0"
                screan(24, 40) = "0"
                screan(24, 42) = "0"
                screan(25, 37) = "0"
                screan(25, 39) = "0"
                screan(25, 41) = "0"
                screan(26, 42) = "0"
            End If

        End Sub

        Public Function getnear(ByRef x As Integer, ByRef y As Integer) As Integer
            Dim count As Integer
            For i = x - 1 To x + 1
                For ii = y - 1 To y + 1
                    If screan(i, ii) = "0" Then
                        count += 1
                    End If
                Next
            Next
            If screan(x, y) = "0" Then
                Return count - 1
            Else
                Return count
            End If
        End Function

        Public Sub update()
            For x = 0 To height
                For y = 0 To width
                    screan(x, y) = lastit(x, y)
                Next
            Next

            For x = 0 To width
                screan(0, x) = "-"
                screan(height, x) = "-"

            Next
            For x = 0 To height
                screan(x, 0) = "-"
                screan(x, width) = "-"
            Next
        End Sub

        Public Sub edit()

        End Sub
    End Class

    Public Class run
        Dim grid As New Grid

        Public Sub New()
            grid.setHeight()
            grid.setwidth()
            grid.setScrean()
        End Sub

        Public Sub start()
            grid.display()
            grid.generation()
            grid.update()
        End Sub

    End Class
End Module