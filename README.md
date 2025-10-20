Project Description:

goal
  console application that can do simple calculations depending on the input.
  Handle information about income and expenses and show it in simple tables.
  easy read with simple colors like red for expenses and green for income.

  This is going to be using an agile planning in the way of finishing each function 
  befor starting on the next. 

  start menu -> view transactions -> add transaction -> delete teansactions -> summary
------------------------------------------------------------------------------------------------

The application is based on the spectre.console
it runns in the console. 

when run by VS use 
> dotnet add package Spectre.Console
> dotnet add package Spectre.Console.Cli

------------------------------------------------------------------------------------------------

simple flowchart of the functions
<img width="791" height="531" alt="image" src="https://github.com/user-attachments/assets/a71bc8c4-4c20-4cfd-98d9-4da26c8bed9f" />

A class diagram
<img width="542" height="634" alt="image" src="https://github.com/user-attachments/assets/a3b3714b-ac55-4a41-8c3f-173feb67ca59" />

1. the classes helps alot to split up de code and keep track of what needs to be where, easier to find code you want to add/develope or change.

2. the most challaging part for me was to do one function at the time. i started out solid and keept to one function at the time and finish that before
   i keept going. but after a while when the ideas starts i kinda lost track of where i was working and what was finished and not. which ended up with
   some function having everything it needed and some functions not having all the functions. Ex. addTransaction had the posibility to exit thrugh esc
   but delete function didnt have that possibility.

   i lost stratuctor and ended up restarting the prodject after i got to lost in the sause.

   //milo eriksson 2025-10-20
   
