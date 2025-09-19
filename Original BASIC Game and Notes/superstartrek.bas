10 REM SUPER STARTREK - MAY 16,1978 - REQUIRES 24K MEMORY
30 REM
40 REM ****        **** STAR TREK ****        ****
50 REM **** SIMULATION OF A MISSION OF THE STARSHIP ENTERPRISE,
60 REM **** AS SEEN ON THE STAR TREK TV SHOW.
70 REM **** ORIGIONAL PROGRAM BY MIKE MAYFIELD, MODIFIED VERSION
80 REM **** PUBLISHED IN DEC'S "101 BASIC GAMES", BY DAVE AHL.
90 REM **** MODIFICATIONS TO THE LATTER (PLUS DEBUGGING) BY BOB
100 REM *** LEEDOM - APRIL & DECEMBER 1974,
110 REM *** WITH A LITTLE HELP FROM HIS FRIENDS . . .
120 REM *** COMMENTS, EPITHETS, AND SUGGESTIONS SOLICITED --
130 REM *** SEND TO:  R. C. LEEDOM
140 REM ***           WESTINGHOUSE DEFENSE & ELECTRONICS SYSTEMS CNTR.
150 REM ***           BOX 746, M.S. 338
160 REM ***           BALTIMORE, MD  21203
170 REM ***
180 REM *** CONVERTED TO MICROSOFT 8 K BASIC 3/16/78 BY JOHN GORDERS
190 REM *** LINE NUMBERS FROM VERSION STREK7 OF 1/12/75 PRESERVED AS
200 REM *** MUCH AS POSSIBLE WHILE USING MULTIPLE STATEMENTS PER LINE
205 REM *** SOME LINES ARE LONGER THAN 72 CHARACTERS; THIS WAS DONE
210 REM *** BY USING "?" INSTEAD OF "PRINT" WHEN ENTERING LINES
215 REM ***
220 PRINT:PRINT:PRINT:PRINT:PRINT:PRINT:PRINT:PRINT:PRINT:PRINT:PRINT
221 PRINT "                                    ,------*------,"
222 PRINT "                    ,-------------   '---  ------'"
223 PRINT "                     '-------- --'      / /"
224 PRINT "                         ,---' '-------/ /--,"
225 PRINT "                          '----------------'":PRINT
226 PRINT "                    THE USS ENTERPRISE --- NCC-1701"
227 PRINT:PRINT:PRINT:PRINT:PRINT
260 REM CLEAR 600
261 REM ************** VARIABLE SETUP **************
270 Z$ = "                         "										# 25 spaces
330 DIM G(8, 8)																# galactic quadrants, in 8x8 grid, numbered 1, 1 at top left and 8, 8 at bottom right; populated during initialization
331 DIM C(9, 2)																# course (of navigation) directions (9 is the same as 1; values can be fractional)
332 DIM K(3, 3)																# klingons in current quadrant, at x/y coordinate with energy level; maximum of 3 klingons in quadrant
333 DIM N(3)																# quadrants of current row of long-range scan; negative values indicate edge of galaxy
334 DIM Z(8, 8)																# status of each quadrant; zero to begin with; updated using long and short range scans
335 DIM D(8)																# system device damage status (see lines 8790 to 8807)
370 T = INT(RND(1) * 20 + 20) * 100											# current stardate
371 T0 = T																	# starting stardate
372 T9 = 25 + INT(RND(1) * 10)												# number of stardates to complete mission within (random between 25 and 34)
373 D0 = 0																	# starbase docking status of Enterprise (0 = not docked, 1 = docked)
374 E = 3000																# current energy for running shields and phasers
375 E0 = E																	# maximum energy for running shields and phasers
440 P = 10																	# current number of photon torpedoes
441 P0 = P																	# maximum number of photon torpedoes
442 S9 = 200																# maximum shield level of klingon ships
443 S = 0																	# current energy level assigned to shields
444 B9 = 2																	# starting number of starbases
445 K9 = 0																	# starting number of klingon ships; set when populating galaxy
446 X$ = ""																	# plural modifier; holds empty string when single item, "s" when multiple items
447 X0$ = " IS "															# plural modifier; holds "is" for single item; "are" for multiple items
460 REM USER DEFINED FUNCTIONS
470 DEF FND(D) = SQR((K(I, 1) - S1) ^ 2 + (K(I, 2) - S2) ^ 2)				# distance between klingon and Enterprise; affects amount of damage done by phaser blast
475 DEF FNR(R) = INT(RND(R) * 7.98 + 1.01)									# random number between 1 and 8
480 REM INITIALIZE ENTERPRIZE'S POSITION
490 Q1 = FNR(1)																# quadrant x Enterprise is in
491 Q2 = FNR(1)																# quadrant y Enterprise is in
492 S1 = FNR(1)																# sector x Enterprise is in
493 S2 = FNR(1)																# sector y Enterprise is in
530 FOR I = 1 TO 9															# courses, in relation to the Enterprise
531 	C(I, 1) = 0																# this is based on a 3x3 grid, where the Enterprise
532 	C(I, 2) = 0																# is at the center point
533 NEXT I																		# +--------+--------+--------+
540 C(1, 2) = 1																	# | -1, -1 | -1,  0 | -1,  1 |	-
541 C(2, 1) = -1																# +--------+--------+--------+	^
542 C(2, 2) = 1																	# |  0, -1 |   <*>  |  0,  1 |	0 --> first digit
543 C(3, 1) = -1																# +--------+--------+--------+	v
544 C(4, 1) = -1																# |  1, -1 |  1,  0 |  1,  1 |	+
545 C(4, 2) = -1																# +--------+--------+--------+
546 C(5, 2) = -1																#     -    <    0   >    +
547 C(6, 1) = 1																	#         second digit
548 C(6, 2) = -1
549 C(7, 1) = 1
550 C(8, 1) = 1
551 C(8, 2) = 1
552 C(9, 2) = 1
670 FOR I = 1 TO 8															# initialize damage levels to none
671 	D(I) = 0
672 NEXT I
710 A1$ = "NAVSRSLRSPHATORSHEDAMCOMXXX"										# allowed commands, 3 chars each
810 REM SETUP WHAT EXISTS IN GALAXY . . .
815 REM K3= # KLINGONS  B3= # STARBASES  S3 = # STARS
820 FOR I = 1 TO 8															# for each row of quadrants, top to bottom
821 	FOR J = 1 TO 8														# for each quadrant within the row, left to right
822 		K3 = 0															# start with no klingons
823 		Z(I, J) = 0														# clear out the cumulative galactic scan record
824 		R1 = RND(1)														# random number to determine number of klingons in quadrant
850 		IF R1 > .98 THEN												# if random is greater than 0.98, the quadrant has:
851				K3 = 3															# 3 klingons
852				K9 = K9 + 3														# total klingons increases by 3
853				GOTO 980
854			IFEND
860 		IF R1 > .95 THEN												# if random is greater than 0.95, the quadrant has:
861				K3 = 2															# 2 klingons
862				K9 = K9 + 2														# total klingons increases by 2
863				GOTO 980
864			IFEND
870 		IF R1 > .80 THEN												# if random is greater than 0.80, the quadrant has:
871				K3 = 1															# 1 klingon
872				K9 = K9 + 1														# total klingons increases by 1
873			IFEND															# if random is less than or equal to 0.80, the quadrant has no klingons
980 		B3 = 0															# start with no starbases
981			IF RND(1) > .96 THEN											# if new random number is more than 0.96, the quadrant has a starbase
982				B3 = 1
983				B9 = B9 + 1
984			IFEND
1040 		G(I, J) = K3 * 100 + B3 * 10 + FNR(1)							# set quadrant status to 3 digit value, KBS, where K = # of klingons, B = # of starbases, S = # of stars (random, 1 to 8)
1041	NEXT J
1042 NEXT I
1043 IF K9 > T9 THEN														# if there are more klingons than stardates to complete the mission in
1044	T9 = K9 + 1																# set it so that there is one more stardate than the klingons
1045 IFEND
1100 IF B9 <> 0 THEN 1200													# if there are starbases, skip to line 1200
1150 IF G(Q1, Q2) < 200 THEN												# if the Enterprise's starting quadrant has less than 2 klingons
1151	G(Q1, Q2) = G(Q1, Q2) + 120												# add a klingon and 2 starbases to the quadrant
1152	K9 = K9 + 1																# increment the total number of klingons
1153 IFEND
1160 B9 = 1																	# set the total number of starbases to 1
1161 G(Q1, Q2) = G(Q1, Q2) + 10												# add another starbase to the quadrant (making a total of 3 in the starting quadrant)
1162 Q1 = FNR(1)															# change the Enterprise's starting quadrant
1163 Q2 = FNR(1)
1200 K7 = K9																# remember how many klingons we started with; used in efficiency rating calculation at line 6400
1201 IF B9 <> 1 THEN														# if we have more than 1 starbase
1202 	X$ = "S"																# adjust the pluralization strings
1203 	X0$ = " ARE "
1204 IFEND
	1230 PRINT "YOUR ORDERS ARE AS FOLLOWS:"
	1240 PRINT "     DESTROY THE";K9;"KLINGON WARSHIPS WHICH HAVE INVADED"
	1252 PRINT "   THE GALAXY BEFORE THEY CAN ATTACK FEDERATION HEADQUARTERS"
	1260 PRINT "   ON STARDATE";T0 + T9;"  THIS GIVES YOU";T9;"DAYS.  THERE";X0$
	1272 PRINT "  ";B9;"STARBASE";X$;" IN THE GALAXY FOR RESUPPLYING YOUR SHIP"
	1280 PRINT
	1281 REM PRINT"HIT ANY KEY EXCEPT RETURN WHEN READY TO ACCEPT COMMAND"
	1300 I = RND(1)																# generate a random number; not sure why
	1301 REM IF INP(1)=13 THEN 1300
	1310 REM HERE ANY TIME NEW QUADRANT ENTERED
	1320 Z4 = Q1																# grab the Enterprise's current quadrant
	1321 Z5 = Q2
1322 K3 = 0																	# clear the current number of klingons, starbases and stars in the quadrant
1323 B3 = 0
1324 S3 = 0
	1325 G5 = 0																	# display the quadrant number with the name
	1326 D4 = .5 * RND(1)														# generate a random number between 0 and 0.5, exclusively, for adjusting damage repair time; see line 5781
	1327 Z(Q1, Q2) = G(Q1, Q2)													# update the cumulative galactic scan record
	1390 IF Q1 < 1 OR Q1 > 8 OR Q2 < 1 OR Q2 > 8 THEN 1600						# if we are somehow outside of the galaxy, skip to 1600
	1430 GOSUB 9030																# display the quadrant name and region
	1431 PRINT
	1432 IF T0 <> T THEN 1490													# if we aren't at the start of the mission, skip to 1490
	1460 PRINT "YOUR MISSION BEGINS WITH YOUR STARSHIP LOCATED"					# display the "starting mission" message
	1470 PRINT "IN THE GALACTIC QUADRANT, '";G2$;"'."
	1471 GOTO 1500
	1490 PRINT "NOW ENTERING ";G2$;" QUADRANT . . ."							# tell them what quadrant they're entering
	1500 PRINT
1501 K3 = INT(G(Q1, Q2) * .01)												# extract the number of klingons in the quadrant
1502 B3 = INT(G(Q1, Q2) * .1) - 10 * K3										# extract the number of starbases in the quadrant
1540 S3 = G(Q1, Q2) - 100 * K3 - 10 * B3									# extract the number of stars in the quadrant
1541 IF K3 = 0 THEN 1590													# if there's no klingon in the quadrant, don't display the "red alert" message
1560 PRINT "COMBAT AREA      CONDITION RED"
1561 IF S > 200 THEN 1590													# if shields are at more than 200 energy, don't display the "dangerously low" message
1580 PRINT "   SHIELDS DANGEROUSLY LOW"
1590 FOR I = 1 TO 3															# initialize the locations and shield levels of the klingons in the quadrant
1591 	K(I, 1) = 0
1592 	K(I, 2) = 0
1593 NEXT I
1600 FOR I = 1 TO 3
1601 	K(I, 3) = 0
1602 NEXT I
1603 Q$ = Z$ + Z$ + Z$ + Z$ + Z$ + Z$ + Z$ + LEFT$(Z$, 17)					# build a string of 192 spaces, with 3 spaces per sector; effectively 8 rows of 24 characters each
1660 REM POSITION ENTERPRISE IN QUADRANT, THEN PLACE "K3" KLINGONS, &
1670 REM "B3" STARBASES, & "S3" STARS ELSEWHERE.
1680 A$ = "<*>"																# put the Enterprise into the appropriate sector in the quadrant string
1681 Z1 = S1																# put its current sector into the variables needed by the subroutine
1682 Z2 = S2
1683 GOSUB 8670
1684 IF K3 < 1 THEN 1820													# if there's no klingons in the quadrant, skip over placing them
1720 FOR I = 1 TO K3														# for each klingon in the quadrant
1721 	GOSUB 8590																# try random sectors in the quadrant until you find an empty one
1722 	A$ = "+K+"
1723 	Z1 = R1
1724 	Z2 = R2
1780 	GOSUB 8670																# place the klingon ship there
1781 	K(I, 1) = R1															# set the sector for the klingon ship
1782 	K(I, 2) = R2
1783 	K(I, 3) = S9 * (0.5 + RND(1))											# assign it a random amount of energy, from ~ 0 to 300
1784 NEXT I
1820 IF B3 < 1 THEN 1910													# if there's no starbases in the quadrant, skip over placing them
1880 GOSUB 8590																# try random sectors in the quadrant until you find an empty one
1881 A$ = ">!<"																# put the starbase at the randomly generated sector
1882 Z1 = R1
1883 Z2 = R2
1884 GOSUB 8670
	1885 B4 = R1																# keep track of the starbase's sector in the quadrant
	1886 B5 = R2
1910 FOR I = 1 TO S3														# for each star in the quadrant
1911 	GOSUB 8590																# try random sectors in the quadrant until you find an empty one
1912 	A$ = " * "																# place the star there
1913 	Z1 = R1
1914 	Z2 = R2
1915 	GOSUB 8670
1916 NEXT I
	1980 GOSUB 6430																# perform a short range sensor scan, if possible
	1990 IF S + E > 10 THEN														# if shields plus energy is greater than 10
	1991 	IF E > 10 OR D(7) = 0 THEN												# if energy is greater than 10 or shield control damage is at zero
	1992 		GOTO 2060																# allow commands to be entered
	1993 	IFEND
	1994 IFEND
	2020 PRINT																	# if we naturally fall here, report that the ship
	2021 PRINT "** FATAL ERROR **   YOU'VE JUST STRANDED YOUR SHIP IN "			# is stranded without enough energy to maneuver
	2030 PRINT "SPACE"
	2031 PRINT "YOU HAVE INSUFFICIENT MANEUVERING ENERGY,";
	2040 PRINT " AND SHIELD CONTROL"
	2041 PRINT "IS PRESENTLY INCAPABLE OF CROSS";
	2050 PRINT "-CIRCUITING TO ENGINE ROOM!!"
	2051 GOTO 6220																# game over, man!
	2060 INPUT "COMMAND";A$														# what does the player want to do?
	2080 FOR I = 1 TO 9															# loop through the available commands
	2081 	IF LEFT$(A$, 3) <> MID$(A1$, 3 * I - 2, 3) THEN 2160					# if the entered command doesn't match the current one in the list, check the next list item
	2140 	ON I GOTO 2300, 1980, 4000, 4260, 4700, 5530, 5690, 7290, 6270			# if we've found a command, jump off to the controller for it
	2160 NEXT I
	2161 PRINT "ENTER ONE OF THE FOLLOWING:"									# if we fall out naturally here, they entered an invalid command, so display a list of the valid ones
	2180 PRINT "  NAV  (TO SET COURSE)"
	2190 PRINT "  SRS  (FOR SHORT RANGE SENSOR SCAN)"
	2200 PRINT "  LRS  (FOR LONG RANGE SENSOR SCAN)"
	2210 PRINT "  PHA  (TO FIRE PHASERS)"
	2220 PRINT "  TOR  (TO FIRE PHOTON TORPEDOES)"
	2230 PRINT "  SHE  (TO RAISE OR LOWER SHIELDS)"
	2240 PRINT "  DAM  (FOR DAMAGE CONTROL REPORTS)"
	2250 PRINT "  COM  (TO CALL ON LIBRARY-COMPUTER)"
	2260 PRINT "  XXX  (TO RESIGN YOUR COMMAND)"
	2261 PRINT
	2262 GOTO 1990																# pop back up and check energy/shield levels, and prompt for a command again
	2290 REM NAV (COURSE CONTROL) BEGINS HERE
	2300 INPUT "COURSE (0-9)";C1												# prompt for the desired course, which can be fractional between 1.0 and 9.0
	2301 IF C1 = 9 THEN C1 = 1													# if they entered 9, force it to be 1
	2310 IF C1 >= 1 AND C1 < 9 THEN 2350										# if they entered a valid value, go handle it
	2330 PRINT "   LT. SULU REPORTS, 'INCORRECT COURSE DATA, SIR!'"				# complain about the invalid value; could use a check for 0 and respond about cancelling navigation
	2331 GOTO 1990																# go prompt for a new command
	2350 X$ = "8"																# set the maximum warp speed to 8
	2351 IF D(1) < 0 THEN X$ = "0.2"											# if the warp engines are damaged, set the maximum warp speed to 0.2
	2360 PRINT "WARP FACTOR (0-";X$;")";										# prompt for the desired warp speed
	2361 INPUT W1
	2362 IF D(1) < 0 AND W1 > .2 THEN 2470										# if the warp engines are damaged and the desired speed is greater than 0.2, complain
	2380 IF W1 > 0 AND W1 <= 8 THEN 2490										# if the desired warp speed is within range, try to travel
	2390 IF W1 = 0 THEN 1990													# if they entered zero, go prompt for a new command
	2420 PRINT "   CHIEF ENGINEER SCOTT REPORTS 'THE ENGINES WON'T TAKE";		# complain about the warp speed they want, and go prompt for a new command
	2430 PRINT " WARP ";W1;"!'"
	2431 GOTO 1990
	2470 PRINT "WARP ENGINES ARE DAMAGED.  MAXIUM SPEED = WARP 0.2"				# complain that the warp engines are damaged, and go prompt for a new command
	2471 GOTO 1990
	2490 N = INT(W1 * 8 + .5)													# calculate how much energy is required; 8 per full warp factor plus 0.5
	2491 IF E - N >= 0 THEN 2590												# if the enterprise has enough energy, let any klingons in the quadrant move and fire on the Enterprise
	2500 PRINT "ENGINEERING REPORTS   'INSUFFICIENT ENERGY AVAILABLE"			# complain about the insufficient energy
	2510 PRINT "                       FOR MANEUVERING AT WARP";W1;"!'"
	2530 IF S < N - E OR D(7) < 0 THEN 1990										# if the shields are not sufficient to offset the energy needed for travel, or the shields are damaged, go prompt for a new command
	2550 PRINT "DEFLECTOR CONTROL ROOM ACKNOWLEDGES";S;"UNITS OF ENERGY"		# if the shields could provide the needed energy, tell the player, and go prompt for a new command
	2560 PRINT "                         PRESENTLY DEPLOYED TO SHIELDS."
	2570 GOTO 1990
	2580 REM KLINGONS MOVE/FIRE ON MOVING STARSHIP . . .
	2590 FOR I = 1 TO K3														# for each klingon in the quadrant, if any
	2591 	IF K(I, 3) = 0 THEN 2700												# if the klingon has no energy, it's either dead or can't fight, so loop past it
	2610 	A$ = "   "																# clear the klingon's current space
	2611 	Z1 = K(I, 1)
	2612 	Z2 = K(I, 2)
	2613 	GOSUB 8670
	2614 	GOSUB 8590																# find a new random spot for the klingon
	2660 	A$ = "+K+"																# place it in its new spot
	2661 	K(I, 1) = Z1
	2662 	K(I, 2) = Z2
	2663 	GOSUB 8670
	2700 NEXT I
	2701 GOSUB 6000																# let the klingons shoot at and damage the Enterprise
	2702 D1 = 0																	# reset the display damage report header flag to false
	2703 D6 = W1																# set the damage repair amount to the requested warp factor
	2704 IF W1 >= 1 THEN D6 = 1													# if they want to go warp 1 or greater, then limit the damage repair amount to 1
	2770 FOR I = 1 TO 8															# for each of Enterprise's systems
	2771 	IF D(I) >= 0 THEN 2880													# if it isn't damaged, skip to the next system
	2790 	D(I) = D(I) + D6														# repair the system by the damage repair amount
	2791 	IF D(I) > -.1 AND D(I) < 0 THEN											# if the system is between 0 and 10% damaged
	2792 		D(I) = -.1																# force it to be 10% damaged
	2793 		GOTO 2880																# skip to the next system
	2794 	IFEND
	2800 	IF D(I) < 0 THEN 2880													# if the system is still damaged, skip to the next system
	2810 	IF D1 <> 1 THEN															# if the display damage report header flag is not true
	2811 		D1 = 1																	# set it to true
	2812 		PRINT "DAMAGE CONTROL REPORT:  ";										# display the damage report header
	2813 	IFEND
	2840 	PRINT TAB(8);
	2841 	R1 = I																	# display the name of the repaired system
	2842 	GOSUB 8790
	2843 	PRINT G2$;" REPAIR COMPLETED."
	2880 NEXT I
	2881 IF RND(1) > .2 THEN 3070												# in 80% of cases, the Enterprise warps away, taking no damage and experiencing no extra repairs
	2910 R1 = FNR(1)															# pick a random system
	2911 IF RND(1) >= .6 THEN 3000												# in 40% of cases, no random damage occurs, but random extra repairs can happen
	2930 D(R1) = D(R1) - (RND(1) * 5 + 1)										# in the other 60% of cases, the random system is damaged a random amount
	2931 PRINT "DAMAGE CONTROL REPORT:  ";										# tell the player what was damaged
	2960 GOSUB 8790
	2962 PRINT G2$;" DAMAGED"
	2963 PRINT
	2964 GOTO 3070																# if something was damaged, no extra repairs can happen
	3000 D(R1) = D(R1) + RND(1) * 3 + 1											# calculate the random amount of repairs on the random system
	3001 PRINT "DAMAGE CONTROL REPORT:  ";										# tell the player what was repaired
	3030 GOSUB 8790
	3031 PRINT G2$;" STATE OF REPAIR IMPROVED"
	3032 PRINT
	3060 REM BEGIN MOVING STARSHIP
	3070 A$ = "   "																# remove the Enterprise from the quadrant
	3071 Z1 = INT(S1)
	3072 Z2 = INT(S2)
	3073 GOSUB 8670
	3110 X1 = C(C1, 1) + (C(C1 + 1, 1) - C(C1, 1)) * (C1 - INT(C1))				# calculate y-axis change in trajectory
	3140 X2 = C(C1, 2) + (C(C1 + 1, 2) - C(C1, 2)) * (C1 - INT(C1))				# calculate x-axis change in trajectory
	3141 X = S1																	# remember the current quadrant sector of the Enterprise
	3142 Y = S2
	3143 Q4 = Q1																# remember the current quadrant of the Enterprise
	3144 Q5 = Q2
	3170 FOR I = 1 TO N															# for each full unit of energy consumed
	3171 	S1 = S1 + X1															# move the Enterprise in its trajectory
	3172 	S2 = S2 + X2
	3173 	IF S1 < 1 OR S1 >= 9 OR S2 < 1 OR S2 >= 9 THEN 3500						# if the Enterprise is exiting the quadrant, handle moving into the appropriate neighboring quadrant
	3240 	S8 = INT(S1) * 24 + INT(S2) * 3 - 26									# check the sector just moved into
	3241 	IF MID$(Q$, S8, 2) = "  " THEN 3360										# if the sector is empty (no klingon, starbase or star), continue moving
	3320 	S1 = INT(S1 - X1)														# back out of the sector
	3321 	S2 = INT(S2 - X2)
	3322 	PRINT "WARP ENGINES SHUT DOWN AT ";										# report the navigation error
	3350 	PRINT "SECTOR";S1;",";S2;"DUE TO BAD NAVAGATION"
	3351 	GOTO 3370																# exit the loop and place the Enterprise in the new sector
	3360 NEXT I
	3361 S1 = INT(S1)															# set the current sector of the Enterprise
	3362 S2 = INT(S2)
	3370 A$ = "<*>"																# place the Enterprise in the new sector
	3371 Z1 = INT(S1)
	3372 Z2 = INT(S2)
	3373 GOSUB 8670																# update the quadrant map
	3374 GOSUB 3910																# reduce the Enterprise's energy, pulling from the shields if needed
	3375 T8 = 1																	# set the maximum amount of time elapsed in this navigation
	3430 IF W1 < 1 THEN T8 = .1 * INT(10 * W1)									# if the warp speed requested is less than one, set the time elapsed to 10% of the warp speed requested
	3450 T = T + T8																# update the current stardate
	3451 IF T > T0 + T9 THEN 6220												# if there is no more time left, end the game
	3470 REM SEE IF DOCKED, THEN GET COMMAND
	3480 GOTO 1980																# update the short range sensor scan and get the next command
	3490 REM EXCEEDED QUADRANT LIMITS
	3500 X = 8 * Q1 + X + N * X1												# calculate the new quadrant and sector:
	3501 Y = 8 * Q2 + Y + N * X2													# 8 x quadrant + sector + warp factor x trajectory
	3502 Q1 = INT(X / 8)														# extract the new quadrant
	3503 Q2 = INT(Y / 8)
	3504 S1 = INT(X - Q1 * 8)													# extract the new sector
	3550 S2 = INT(Y - Q2 * 8)
	3551 IF S1 = 0 THEN															# if the new sector x coordinate is zero
	3552 	Q1 = Q1 - 1																# move one quadrant to the left
	3553 	S1 = 8																	# set the new sector to the right side of the quadrant
	3554 IFEND
	3590 IF S2 = 0 THEN															# if the new sector y coordinate is zero
	3591 	Q2 = Q2 - 1																# move one quadrant up
	3592 	S2 = 8																	# set the new sector to the bottom of the quadrant
	3593 IFEND
	3620 X5 = 0																	# set the crossing galactic perimeter flag to false
	3621 IF Q1 < 1 THEN															# if the new quadrant x coordinate is less than 1
	3622 	X5 = 1																	# flag that the Enterprise tried to leave the galaxy
	3623 	Q1 = 1																	# set the quadrant and sector x coordinates to the left-most ones
	3624 	S1 = 1
	3625 IFEND
	3670 IF Q1 > 8 THEN															# if the new quadrant x coordinate is greater than 8
	3671 	X5 = 1																	# flag that the Enterprise tried to leave the galaxy
	3672 	Q1 = 8																	# set the quadrant and sector x coordinates to the right-most ones
	3673 	S1 = 8
	3674 IFEND
	3710 IF Q2 < 1 THEN															# if the new quadrant y coordinate is less than 1
	3711 	X5 = 1																	# flag that the Enterprise tried to leave the galaxy
	3712 	Q2 = 1																	# set the quadrant and sector y coordinates to the top-most ones
	3713 	S2 = 1
	3714 IFEND
	3750 IF Q2 > 8 THEN															# if the new quadrant y coordinate is greater than 8
	3751 	X5 = 1																	# flag that the Enterprise tried to leave the galaxy
	3752 	Q2 = 8																	# set the quadrant and sector y coordinates to the bottom-most ones
	3753 	S2 = 8
	3754 IFEND
	3790 IF X5 = 0 THEN 3860													# if the crossing galactic perimeter flag is false, skip over the next message
	3800 PRINT "LT. UHURA REPORTS MESSAGE FROM STARFLEET COMMAND:"				# inform the player that they tried to leave the galaxy and that the warp engines were automatically shut down
	3810 PRINT "  'PERMISSION TO ATTEMPT CROSSING OF GALACTIC PERIMETER"
	3820 PRINT "  IS HEREBY *DENIED*.  SHUT DOWN YOUR ENGINES.'"
	3830 PRINT "CHIEF ENGINEER SCOTT REPORTS  'WARP ENGINES SHUT DOWN"
	3840 PRINT "  AT SECTOR";S1;",";S2;"OF QUADRANT";Q1;",";Q2;".'"
	3850 IF T > T0 + T9 THEN 6220												# if there is no more time left, end the game
	3860 IF 8 * Q1 + Q2 = 8 * Q4 + Q5 THEN 3370									# if the Enterprise is in the same quadrant it started in, then update the quadrant map
	3870 T = T + 1																# if the Enterprise isn't in the same quadrant it started in, increment the current stardate
	3871 GOSUB 3910																# adjust the Enterprise's energy level
	3872 GOTO 1320																# display the current quadrant details
	3900 REM MANEUVER ENERGY S/R **
	3910 E = E - N - 10															# reduce the Enterprise's available energy
	3911 IF E >= 0 THEN RETURN													# if the Enterprise still has energy reserves, we're done
	3930 PRINT "SHIELD CONTROL SUPPLIES ENERGY TO COMPLETE THE MANEUVER."		# otherwise, reduce the shields by the needed energy
	3940 S = S + E
	3941 E = 0																	# set the Enterprise's available energy to zero
	3942 IF S <= 0 THEN S = 0													# if the shields were depleted, set them to zero (doesn't deal with not having enough in shields)
	3980 RETURN
	3990 REM LONG RANGE SENSOR SCAN CODE
	4000 IF D(3) < 0 THEN														# if the long range sensors are damaged
	4001 	PRINT "LONG RANGE SENSORS ARE INOPERABLE"								# report it to the player
	4002 	GOTO 1990																# try for another command
	4003 IFEND
	4030 PRINT "LONG RANGE SCAN FOR QUADRANT";Q1;",";Q2							# if the long range sensors are functional, display the scan
	4040 O1$ = "-------------------"
	4041 PRINT O1$																# begin printing the long range sensor scan
	4060 FOR I = Q1 - 1 TO Q1 + 1												# for the rows of quadrants above, including, and below the one the Enterprise is in
	4061 	N(1) = -1																# reset the scan values for the 3 quadrants in the row
	4062 	N(2) = -2
	4063 	N(3) = -3
	4064 	FOR J = Q2 - 1 TO Q2 + 1												# for the quadrants left of, right of, and including the one the Enterprise is in
	4120 		IF I > 0 AND I < 9 AND J > 0 AND J < 9 THEN								# if the x/y coordinates are valid
	4121 			N(J - Q2 + 2) = G(I, J)													# get the population of the quadrant
	4122 			Z(I, J) = G(I, J)														# update the cumulative galactic record
	4123 		IFEND
	4180 	NEXT J
	4181 	FOR L = 1 TO 3															# for the quadrants in the row
	4182 		PRINT ": ";
	4183 		IF N(L) < 0 THEN														# if the quadrant population is negative, it is outside the galaxy, so display ***
	4184 			PRINT "*** ";
	4185 			GOTO 4230
	4186 		IFEND
	4210 		PRINT RIGHT$(STR$(N(L) + 1000), 3);" ";									# if the quadrant population is positive, display it, zero padded on the left
	4230 	NEXT L
	4231 	PRINT ":"
	4232 	PRINT O1$																# print a row separator
	4233 NEXT I
	4234 GOTO 1990																# try for another command
	4250 REM PHASER CONTROL CODE BEGINS HERE
	4260 IF D(4) < 0 THEN														# if the phasers are damaged
	4261 	PRINT "PHASERS INOPERATIVE"												# report it to the player
	4262 	GOTO 1990																# try for another command
	4263 IFEND
	4265 IF K3 > 0 THEN 4330													# if there are klingons in the quadrant, allow the player to use the phasers
	4270 PRINT "SCIENCE OFFICER SPOCK REPORTS  'SENSORS SHOW NO ENEMY SHIPS"	# report that there are no klingons in the quadrant
	4280 PRINT "                                IN THIS QUADRANT'"
	4281 GOTO 1990																# try for another command
	4330 IF D(8) < 0 THEN PRINT "COMPUTER FAILURE HAMPERS ACCURACY"				# if the computer is damaged, report it to the player
	4350 PRINT "PHASERS LOCKED ON TARGET;  ";
	4360 PRINT "ENERGY AVAILABLE =";E;"UNITS"									# tell the player how much energy is available
	4370 INPUT "NUMBER OF UNITS TO FIRE";X										# ask for how much to use
	4371 IF X <= 0 THEN 1990													# if the energy specified is zero or less, try for another command
	4400 IF E - X < 0 THEN 4360													# if there isn't enough energy, report what is available and ask again
	4410 E = E - X																# decrement the remaining energy
	4411 IF D(7) < 0 THEN X = X * RND(1)										# if the shields are damaged, randomly decrease the energy
	4450 H1 = INT(X / K3)														# split the energy across all the klingons in the quadrant
	4451 FOR I = 1 TO 3															# for each klingon in the quadrant
	4452 	IF K(I, 3) <= 0 THEN 4670												# if the klingon has no energy, it is either dead or non-existent, so skip further processing
	4480 	H = INT((H1 / FND(0)) * (RND(1) + 2))									# calculate how much the klingon is potentially hit for
	4481 	IF H > .15 * K(I, 3) THEN 4530											# if the potential damage is more than 15% of the klingon's energy, it lands
	4500 	PRINT "SENSORS SHOW NO DAMAGE TO ENEMY AT ";K(I, 1);",";K(I, 2)			# otherwise, it does nothing, so skip to the next klingon
	4501 	GOTO 4670
	4530 	K(I, 3) = K(I, 3) - H													# the hit lands, so reduce the klingon's energy
	4531 	PRINT H;"UNIT HIT ON KLINGON AT SECTOR";K(I, 1);",";					# report the hit to the player
	4550 	PRINT K(I, 2)
	4551 	IF K(I, 3) <= 0 THEN													# if the klingon's energy drops to zero or below
	4552 		PRINT "*** KLINGON DESTROYED ***"										# report it as destroyed
	4553 		GOTO 4580																# remove it from the quadrant map
	4554 	IFEND
	4560 	PRINT "   (SENSORS SHOW";K(I, 3);"UNITS REMAINING)"						# if it wasn't destroyed, show its remaining energy
	4561 	GOTO 4670																# skip to the next klingon
	4580 	K3 = K3 - 1																# reduce the number of klingons in the quadrant
	4581 	K9 = K9 - 1																# reduce the total number of klingons in the galaxy
	4582	A$ = "   "																# remove it from the quadrant map
	4583 	Z1 = K(I, 1)
	4584 	Z2 = K(I, 2)
	4585 	GOSUB 8670
	4650 	K(I, 3) = 0																# zero out its energy
	4651 	G(Q1, Q2) = G(Q1, Q2) - 100												# update the galactic map to remove the klingon
	4652 	Z(Q1, Q2) = G(Q1, Q2)													# update the cumulative galactic scan history
	4653 	IF K9 <= 0 THEN 6370													# if there are no more klingons, the player has won!
	4670 NEXT I
	4671 GOSUB 6000																# let the klingons move and fire, if any remain
	4672 GOTO 1990																# try for another command
	4690 REM PHOTON TORPEDO CODE BEGINS HERE
4700 IF P <= 0 THEN															# if there are no photon torpedoes left
4701 	PRINT "ALL PHOTON TORPEDOES EXPENDED"									# inform the player
4702 	GOTO 1990																# try for another command
4703 IFEND
4730 IF D(5) < 0 THEN														# if the photon torpedoe tubes are damaged
4731 	PRINT "PHOTON TUBES ARE NOT OPERATIONAL"								# inform the player
4732 	GOTO 1990																# try for another command
4733 IFEND
	4760 INPUT "PHOTON TORPEDO COURSE (1-9)";C1									# prompt for the desired course to launch it in
	4761 IF C1 = 9 THEN C1 = 1													# if they entered 9, force it to be 1
	4780 IF C1 >= 1 AND C1 < 9 THEN 4850										# if they entered a valid value, go handle it
	4790 PRINT "ENSIGN CHEKOV REPORTS,  'INCORRECT COURSE DATA, SIR!'"			# complain about the invalid value; could use a check for 0 and respond about cancelling launch
	4800 GOTO 1990																# try for another command
4850 X1 = C(C1, 1) + (C(C1 + 1, 1) - C(C1, 1)) * (C1 - INT(C1))				# calculate the y-axis trajectory
4860 X2 = C(C1, 2) + (C(C1 + 1, 2) - C(C1, 2)) * (C1 - INT(C1))				# calculate the x-axis trajectory
	4861 E = E - 2																# decrease the available energy by 2; need a check to see if there is enough energy to launch a photon torpedoe
	4862 P = P - 1																# decrease the number of photon torpedoes
	4863 X = S1																	# grab the current quadrant sector (launch point)
	4864 Y = S2
4910 PRINT "TORPEDO TRACK:"													# tell the player what's going on
4920 X = X + X1																# update the torpedoe's position
4921 Y = Y + X2
4922 X3 = INT(X + .5)														# round off the position
4923 Y3 = INT(Y + .5)
4960 IF X3 < 1 OR X3 > 8 OR Y3 < 1 OR Y3 > 8 THEN 5490						# if the torpedoe has left the quadrant, tell the player it missed
5000 PRINT "               ";X3;",";Y3										# otherwise, display the current coordinate track
5001 A$ = "   "																# check if the sector is empty
5002 Z1 = X
5003 Z2 = Y
5004 GOSUB 8830
5050 IF Z3 <> 0 THEN 4920													# if the sector is empty, continue tracking the torpedoe
	5060 A$ = "+K+"																# check if the sector has a klingon in it
	5061 Z1 = X
	5062 Z2 = Y
	5063 GOSUB 8830
	5064 IF Z3 = 0 THEN 5210													# if it isn't a klingon, check if it is a star or starbase
	5110 PRINT "*** KLINGON DESTROYED ***"										# tell the player they destroyed the klingon
	5111 K3 = K3 - 1															# decrease the number of klingons in the quadrant
	5112 K9 = K9 - 1															# decrease the number of klingons in the galaxy
	5113 IF K9 <= 0 THEN 6370													# if there are no more klingons in the galaxy, the player has won!
	5150 FOR I = 1 TO 3															# for each klingon in the quadrant
	5151 	IF X3 = K(I, 1) AND Y3 = K(I, 2) THEN 5190								# if they were the one just destroyed, remove them from the quadrant map
	5180 NEXT I
	5181 I = 3																	# if it naturally falls out of the loop, override I so that it is pointing at the end of the array instead of 1 past it
	5190 K(I, 3) = 0															# set the klingon's energy level to zero
	5191 GOTO 5430																# drop down and clear the sector in the quadrant map
	5210 A$ = " * "																# check if the sector has a star in it
	5211 Z1 = X
	5212 Z2 = Y
	5213 GOSUB 8830
	5214 IF Z3 = 0 THEN 5280													# if it isn't a star, check if it is a starbase
	5260 PRINT "STAR AT";X3;",";Y3;"ABSORBED TORPEDO ENERGY."					# tell the player they shot a star and wasted a torpedoe
	5261 GOSUB 6000																# let the klingons in the quadrant shoot at the Enterprise
	5262 GOTO 1990																# try for another command
	5280 A$ = ">!<"																# check if the sector has a starbase in it
	5281 Z1 = X
	5282 Z2 = Y
	5283 GOSUB 8830
	5284 IF Z3 = 0 THEN 4760													# if it isn't a starbase, allow the player to fire another torpedoe; should go to 4700 instead, because this would allow them to fire with no torpedoes
	5330 PRINT "*** STARBASE DESTROYED ***"										# tell the player they shot a starbase
	5331 B3 = B3 - 1															# decrease the number of starbases in the quadrant
	5332 B9 = B9 - 1															# decrease the number of starbases in the galaxy
	5360 IF B9 > 0 OR K9 > T - T0 - T9 THEN 5400								# if there are still starbases or there is enough time to destroy the remaining klingons, let the player continue
	5370 PRINT "THAT DOES IT, CAPTAIN!!  YOU ARE HEREBY RELIEVED OF COMMAND"	# there's no starbases left, so relieve the player of command
	5380 PRINT "AND SENTENCED TO 99 STARDATES AT HARD LABOR ON CYGNUS 12!!"
	5390 GOTO 6270																# report how many klingons are left and end the game
	5400 PRINT "STARFLEET COMMAND REVIEWING YOUR RECORD TO CONSIDER"			# warn the player about destroying starbases
	5410 PRINT "COURT MARTIAL!"
	5411 D0 = 0																	# if the Enterprise was docked at the destroyed starbase, consider them undocked
	5430 A$ = "   "																# clear the sector of whatever was in it
	5431 Z1 = X
	5432 Z2 = Y
	5433 GOSUB 8670
	5470 G(Q1, Q2) = K3 * 100 + B3 * 10 + S3									# update the galactic map to remove whatever was destroyed
	5471 Z(Q1, Q2) = G(Q1, Q2)													# update the cumulative galactic scan history
	5472 GOSUB 6000																# let the klingons in the quadrant shoot at the Enterprise
	5473 GOTO 1990																# try for another command
	5490 PRINT "TORPEDO MISSED"													# tell the player the torpedoe missed
	5491 GOSUB 6000																# let the klingons in the quadrant shoot at the Enterprise
	5492 GOTO 1990																# try for another command
	5520 REM SHIELD CONTROL
	5530 IF D(7) < 0 THEN														# if the shields are damaged
	5531 	PRINT "SHIELD CONTROL INOPERABLE"										# report that to the player
	5532 	GOTO 1990																# try for another command
	5533 IFEND
	5560 PRINT "ENERGY AVAILABLE =";E + S;										# tell the player how much energy is available, including that assigned to shields
	5561 INPUT "NUMBER OF UNITS TO SHIELDS";X									# ask how much should be assigned to the shields
5580 IF X < 0 OR S = X THEN													# if the entered value is negative or the same as what is currently assigned
	5581 	PRINT "<SHIELDS UNCHANGED>"												# tell the player that shields didn't change
	5582 	GOTO 1990																# try for another command
	5583 IFEND
5590 IF X <= E + S THEN 5630												# if the requested energy is not more than the total energy available, change the shields
	5600 PRINT "SHIELD CONTROL REPORTS  'THIS IS NOT THE FEDERATION TREASURY.'"	# tell the player there isn't enough energy
	5610 PRINT "<SHIELDS UNCHANGED>"
	5611 GOTO 1990																# try for another command
5630 E = E + S - X															# adjust the Enterprise's main energy level
5631 S = X																	# adjust the shield's energy level
	5632 PRINT "DEFLECTOR CONTROL ROOM REPORT:"									# tell the player what the current shield energy level is
	5660 PRINT "  'SHIELDS NOW AT";INT(S);"UNITS PER YOUR COMMAND.'"
	5661 GOTO 1990																# try for another command
	5680 REM DAMAGE CONTROL
	5690 IF D(6) >= 0 THEN 5910													# if the damage control system is not damaged, produce the damage report
	5700 PRINT "DAMAGE CONTROL REPORT NOT AVAILABLE"							# tell the player the damage control system is damaged
	5701 IF D0 = 0 THEN 1990													# if the Enterprise is not docked at a starbase, try for another command
	5720 D3 = 0																	# prepare to estimate the time needed to repair damaged systems
	5721 FOR I = 1 TO 8															# for each of the Enterprise's systems
	5722 	IF D(I) < 0 THEN D3 = D3 + .1											# if the system is damaged, add on 1/10th of a stardate for repairs
	5760 NEXT I
	5761 IF D3 = 0 THEN 1990													# if there's no estimate, try for another command
	5780 PRINT
	5781 D3 = D3 + D4															# add in the randomly generated damage repair time for the quadrant
	5782 IF D3 >= 1 THEN D3 = .9												# if the time is a full stardate or more, reduce it to 9/10ths of a stardate
	5810 PRINT "TECHNICIANS STANDING BY TO EFFECT REPAIRS TO YOUR SHIP;"		# tell the player how long repairs will take if authorized
	5820 PRINT "ESTIMATED TIME TO REPAIR:";.01 * INT(100 * D3);"STARDATES"
	5840 INPUT "WILL YOU AUTHORIZE THE REPAIR ORDER (Y/N)";A$					# prompt for the player's approval
	5860 IF A$ <> "Y" THEN 1990													# if the player doesn't approve, try for another command
	5870 FOR I = 1 TO 8															# for each of the Enterprise's systems
	5871 	IF D(I) < 0 THEN D(I) = 0												# if the system is damaged, remove the damage
	5890 NEXT I
	5891 T = T + D3 + .1														# increase the current stardate by the repair time
	5910 PRINT
	5911 PRINT "DEVICE             STATE OF REPAIR"								# produce a system status report
	5912 FOR R1 = 1 TO 8														# for each of the Enterprise's systems
	5920 	GOSUB 8790																# get the system's name
	5921 	PRINT G2$;LEFT$(Z$, 25 - LEN(G2$));INT(D(R1) * 100) * .01				# display it with it's current damage level
	5950 NEXT R1
	5951 PRINT
	5952 IF D0 <> 0 THEN 5720													# if the Enterprise is docked, check if any damage is left
	5980 GOTO 1990																# otherwise, try for another command
	5990 REM KLINGONS SHOOTING
	6000 IF K3 <= 0 THEN RETURN													# if there are no klingons in the quadrant, return
	6010 IF D0 <> 0 THEN														# if the Enterprise is docked at a starbase, it can't be hurt, so return
	6011 	PRINT "STARBASE SHIELDS PROTECT THE ENTERPRISE"
	6012 	RETURN
	6013 IFEND
	6040 FOR I = 1 TO 3															# for each of the possible klingons (this should limit to K3, not just 3, because not all quadrants have 3 klingons in them)
	6041 	IF K(I, 3) <= 0 THEN 6200												# if the klingon has no energy, skip over the processing
	6060 	H = INT((K(I, 3) / FND(1)) * (2 + RND(1)))								# calculate the hit the Enterprise takes; integer((klingon's full energy / distance) * (2 + random between 0 and 1, exclusive))
	6061 	S = S - H																# decrease the Enterprise's shields by the hit
	6062 	K(I, 3) = K(I, 3) / (3 + RND(0))										# decrease the klingon's remaining energy (current energy / (3 + random number between 0 and 1, exclusive))
	6080 	PRINT H;"UNIT HIT ON ENTERPRISE FROM SECTOR";K(I, 1);",";K(I, 2)		# report the hit the Enterprise took
	6090 	IF S <= 0 THEN 6240														# if the Enterprise's shields have been depleted, report the ship has been destroyed
	6100 	PRINT "      <SHIELDS DOWN TO";S;"UNITS>"								# report the new shield level
	6101 	IF H < 20 THEN 6200														# if the hit was under 20, skip to the next klingon
	6120 	IF RND(1) > .6 OR H / S <= .02 THEN 6200								# if a random number is greater than 0.6, or the hit:shield ratio is less than 0.02, skip to the next klingon
	6140 	R1 = FNR(1)																# get a random number between 1 and 8
	6141 	D(R1) = D(R1) - H / S - .5 * RND(1)										# set the damage level of that random system, based on how much got through the shields
	6142 	GOSUB 8790																# get the name of the system damaged
	6170 	PRINT "DAMAGE CONTROL REPORTS ";G2$;" DAMAGED BY THE HIT'"				# report that it was damaged
	6200 NEXT I
	6201 RETURN
	6210 REM END OF GAME
	6220 PRINT "IT IS STARDATE";T												# report the current stardate
	6221 GOTO 6270																# skip over the "enterprise destroyed" message
	6240 PRINT
	6241 PRINT "THE ENTERPRISE HAS BEEN DESTROYED.  THE FEDERATION ";
	6250 PRINT "WILL BE CONQUERED"
	6251 GOTO 6220																# go back and report the current stardate
	6270 PRINT "THERE WERE";K9;"KLINGON BATTLE CRUISERS LEFT AT"				# report how many klingons were left
	6280 PRINT "THE END OF YOUR MISSION."
	6290 PRINT
	6291 PRINT
	6292 IF B9 = 0 THEN 6360													# if there are no starbases left, end the program
	6310 PRINT "THE FEDERATION IS IN NEED OF A NEW STARSHIP COMMANDER"			# allow the game to be restarted if there are still starbases
	6320 PRINT "FOR A SIMILAR MISSION -- IF THERE IS A VOLUNTEER,"
	6330 INPUT "LET HIM STEP FORWARD AND ENTER 'AYE'";A$
	6331 IF A$ = "AYE" THEN 10													# if someone signs up, restart the game
	6360 END
	6370 PRINT "CONGRATULATIONS, CAPTAIN!  THE LAST KLINGON BATTLE CRUISER"		# all klingons have been destroyed
	6380 PRINT "MENACING THE FEDERATION HAS BEEN DESTROYED."
	6381 PRINT
	6400 PRINT "YOUR EFFICIENCY RATING IS";1000 * (K7 / (T - T0)) ^ 2			# tell the player how they did
	6401 GOTO 6290																# allow them to play again
	6420 REM SHORT RANGE SENSOR SCAN & STARTUP SUBROUTINE
	6430 FOR I = S1 - 1 TO S1 + 1												# for the rows of sectors above, including, and below the one the Enterprise is in
	6431 	FOR J = S2 - 1 TO S2 + 1												# for the sectors left of, right of, and including the one the Enterprise is in
	6450 		IF INT(I + .5) < 1 OR INT(I + .5) > 8 OR INT(J + .5) < 1 OR INT(J + .5) > 8 THEN 6540		# if the x/y coordinates aren't valid (1-8), skip to 6540
	6490 		A$ = ">!<"																# check if there is a starbase in the sector
	6491 		Z1 = I
	6492 		Z2 = J
	6493 		GOSUB 8830
	6494 		IF Z3 = 1 THEN 6580														# if the current sector contains a starbase, show the Enterprise as docked
	6540 	NEXT J
	6541 NEXT I
	6542 D0 = 0																	# if we fall out of the loop naturally, the Enterprise isn't docked
	6543 GOTO 6650																# skip forward to check for klingons
	6580 D0 = 1																	# the Enterprise is docked
	6581 C$ = "DOCKED"
	6582 E = E0																	# restore the Enterprise's energy level
	6583 P = P0																	# replenish the Enterprise's photon torpedoe stocks
	6620 PRINT "SHIELDS DROPPED FOR DOCKING PURPOSES"
	6621 S = 0																	# drop the Enterprise's shields, since it is protected by the starbase
	6622 GOTO 6720																# skip over the klingon check
	6650 IF K3 > 0 THEN															# if there are klingons in the sector, set the alert status to red
	6651 	C$ = "*RED*"
	6652 	GOTO 6720																# skip past the green/yellow status checks
	6653 IFEND
	6660 C$ = "GREEN"															# start off with green status
	6661 IF E < E0 * .1 THEN C$ = "YELLOW"										# if energy reserves are at less than 10% of full, set status to yellow
	6720 IF D(2) >= 0 THEN 6770													# if damage to short range sensors is not negative, then they are operative
	6730 PRINT																	# if damage to short range sensors is negative, say they are inoperative
	6731 PRINT "*** SHORT RANGE SENSORS ARE OUT ***"
	6732 PRINT
	6733 RETURN																	# if the short range sensors are out, the quadrant scan and status update are not displayed
	6770 O1$ = "---------------------------------"
	6771 PRINT O1$																# begin printing a short range scan with status
	6772 FOR I = 1 TO 8															# for each row of sectors in the quadrant
	6820 	FOR J = (I - 1) * 24 + 1 TO (I - 1) * 24 + 22 STEP 3					# for each sector in the row
	6821 		PRINT " ";MID$(Q$, J, 3);												# display what is in that sector
	6822 	NEXT J
	6830 	ON I GOTO 6850, 6900, 6960, 7020, 7070, 7120, 7180, 7240				# print a different status for each row
	6850 	PRINT "        STARDATE          ";INT(T * 10) * .1
	6851 	GOTO 7260
	6900 	PRINT "        CONDITION          ";C$
	6901 	GOTO 7260
	6960 	PRINT "        QUADRANT          ";Q1;",";Q2
	6961 	GOTO 7260
	7020 	PRINT "        SECTOR            ";S1;",";S2
	7021 	GOTO 7260
	7070 	PRINT "        PHOTON TORPEDOES  ";INT(P)
	7071 	GOTO 7260
	7120 	PRINT "        TOTAL ENERGY      ";INT(E + S)
	7121 	GOTO 7260
	7180 	PRINT "        SHIELDS           ";INT(S)
	7181 	GOTO 7260
	7240 	PRINT "        KLINGONS REMAINING";INT(K9)
	7260 NEXT I
	7261 PRINT O1$																# mark off the end of the status update
	7262 RETURN
	7280 REM LIBRARY COMPUTER CODE
	7290 IF D(8) < 0 THEN														# if the computer is damaged
	7291 	PRINT "COMPUTER DISABLED"												# tell the player about it
	7292 	GOTO 1990																# try for another command
	7293 IFEND
	7320 INPUT "COMPUTER ACTIVE AND AWAITING COMMAND";A							# prompt the player for a computer command, which is a number
	7321 IF A < 0 THEN 1990														# if the computer command is a negative number, try for another general command
	7350 PRINT
	7351 H8 = 1																	# flag to change the map displayed; when 0, display galactic quadrant map; when 1, display quadrant sector details
	7352 ON A + 1 GOTO 7540, 7900, 8070, 8500, 8150, 7400						# perform the requested action
	7360 PRINT "FUNCTIONS AVAILABLE FROM LIBRARY-COMPUTER:"						# if they entered an invalid number, display a list of computer commands
	7370 PRINT "   0 = CUMULATIVE GALACTIC RECORD"
	7372 PRINT "   1 = STATUS REPORT"
	7374 PRINT "   2 = PHOTON TORPEDO DATA"
	7376 PRINT "   3 = STARBASE NAV DATA"
	7378 PRINT "   4 = DIRECTION/DISTANCE CALCULATOR"							# this one leaps into the middle of a loop that isn't looping
	7380 PRINT "   5 = GALAXY 'REGION NAME' MAP"
	7381 PRINT
	7382 GOTO 7320																# try for another computer command
	7390 REM SETUP TO CHANGE CUM GAL RECORD TO GALAXY MAP
	7400 H8 = 0																	# make the map display the galaxy quadrant summaries
	7401 G5 = 1																	# display the quadrant name, but no number
	7402 PRINT "                        THE GALAXY"
	7403 GOTO 7550																# skip to the printout
	7530 REM CUM GALACTIC RECORD
	7540 REM INPUT"DO YOU WANT A HARDCOPY? IS THE TTY ON (Y/N)";A$
	7542 REM IFA$="Y"THENPOKE1229,2:POKE1237,3:NULL1
	7543 PRINT
	7544 PRINT "        ";
	7544 PRINT "COMPUTER RECORD OF GALAXY FOR QUADRANT";Q1;",";Q2				# display the title for the quadrant details
	7546 PRINT
	7550 PRINT "       1     2     3     4     5     6     7     8"
	7560 O1$ = "     ----- ----- ----- ----- ----- ----- ----- -----"
	7570 PRINT O1$
	7571 FOR I = 1 TO 8															# for each row in the map
	7572 	PRINT I;																# print the row number
	7573 	IF H8 = 0 THEN 7740														# if we're displaying the galaxy region names, skip down to display the quadrant name
	7630 	FOR J = 1 TO 8															# for each quadrant in the row
	7631 		PRINT "   ";															# print a spacer
	7632 		IF Z(I, J) = 0 THEN														# if the quadrant hasn't been scanned before
	7633 			PRINT "***";															# display ***
	7634 			GOTO 7720																# skip to the next quadrant in the row
	7635 		IFEND
	7700 		PRINT RIGHT$(STR$(Z(I, J) + 1000), 3);									# otherwise, display the quadrant's summary
	7720 	NEXT J
	7721 	GOTO 7850																# skip over displaying galactic region names and numbers
	7740 	Z4 = I																	# prepare to display the left-hand galactic region name
	7741 	Z5 = 1
	7742 	GOSUB 9030																# get the galactic region name
	7743 	J0 = INT(15 - .5 * LEN(G2$))											# display it
	7744 	PRINT TAB(J0);G2$;
	7800 	Z5 = 5																	# prepare to display the right-hand galactic region name
	7801 	GOSUB 9030																# get the galactic region name
	7802 	J0 = INT(39 - .5 * LEN(G2$))											# display it
	7803 	PRINT TAB(J0);G2$;
	7850 	PRINT
	7851 	PRINT O1$																# display the row separator
	7852 NEXT I
	7853 PRINT
	7854 GOTO 1990																# try for another command
	7890 REM STATUS REPORT
	7900 PRINT "   STATUS REPORT:"												# display a status report
	7901 X$ = ""																# prep the plural indicator
	7902 IF K9 > 1 THEN X$ = "S"												# if there's more than 1 klingon, adjust the plural indicator
	7940 PRINT "KLINGON";X$;" LEFT: ";K9										# state how many klingons are left in the galaxy
	7960 PRINT "MISSION MUST BE COMPLETED IN";.1 * INT((T0 + T9 - T) * 10);"STARDATES"		# state how many stardates are left
	7970 X$ = "S"																# prep the plural indicator
	7971 IF B9 < 2 THEN															# if there are less than 2 starbases
	7972 	X$ = ""																	# adjust the plural indicator
	7973 	IF B9 < 1 THEN 8010														# if there no starbases remaining, tell the player they're an idiot
	7974 IFEND
	7980 PRINT "THE FEDERATION IS MAINTAINING";B9;"STARBASE";X$;" IN THE GALAXY"	# tell the player how many starbases remain
	7990 GOTO 5690																# display a damage control report
	8010 PRINT "YOUR STUPIDITY HAS LEFT YOU ON YOUR OWN IN"						# tell the user they're an stranded with no starbases to support them
	8020 PRINT "  THE GALAXY -- YOU HAVE NO STARBASES LEFT!"
	8021 GOTO 5690																# display a damage control report
	8060 REM TORPEDO, BASE NAV, D/D CALCULATOR
	8070 IF K3 <= 0 THEN 4270													# if there are no klingons in the quadrant, report it and try for another command
	8080 X$ = ""																# reset the plural indicator
	8081 IF K3 > 1 THEN X$ = "S"												# if there are more than 1 klingons in the quadrant, adjust the plural indicator
	8090 PRINT "FROM ENTERPRISE TO KLINGON BATTLE CRUISER";X$
	8100 H8 = 0
	8101 FOR I = 1 TO 3															# for each potential klingon in the quadrant
	8102 	IF K(I, 3) <= 0 THEN 8480												# if the klingon has no energy, skip to the next klingon
8110 	W1 = K(I, 1)															# grab the klingon's sector coordinates
8111 	X = K(I, 2)
8120 	C1 = S1																	# grab the Enterprise's current sector
8121 	A = S2
	8122 	GOTO 8220																# skip over the direction/distance calculator prompt when working on klingons
	8150 	PRINT "DIRECTION/DISTANCE CALCULATOR:"									# note that x-axis is on the vertical, and y-axis is on the horizontal, which is flipped from normal
	8160 	PRINT "YOU ARE AT QUADRANT ";Q1;",";Q2;" SECTOR ";S1;",";S2
	8170 	PRINT "PLEASE ENTER"
	8171 	INPUT "  INITIAL COORDINATES (X,Y)";C1,A
	8200 	INPUT "  FINAL COORDINATES (X,Y)";W1,X
8220 	X = X - A																# determine the distance between on the y-axis
8221 	A = C1 - W1																# determine the distance on the x-axis
8222 	IF X < 0 THEN 8350														# if the y-axis distance is negative, the target is to the left
8250 	IF A < 0 THEN 8410														# if the x-axis distance is negative, the target is above
8260 	IF X > 0 THEN 8280														# if the y-axis distance is positive, the target is to the right
8270 	IF A = 0 THEN															# if the x-axis distance is zero, the target is directly left
8271 		C1 = 5																	# adjust the starting direction pointing left
8272 		GOTO 8290																# skip to the left/right direction calculator
8273 	IFEND
8280 	C1 = 1																	# in all other cases, adjust the starting direction pointing right
8290 	IF ABS(A) <= ABS(X) THEN 8330											# if the abs(y-axis distance) is not greater than the abs(x-axis distance), adjust a fractional amount counter-clockwise
8310 	PRINT "DIRECTION =";C1 + (((ABS(A) - ABS(X)) + ABS(A)) / ABS(A))		# otherwise, adjust a grosser amount counter-clockwise
8311 	GOTO 8460																# skip to the distance calculation
8330 	PRINT "DIRECTION =";C1 + (ABS(A) / ABS(X))								# calculate the fractional amount counter-clockwise
8331 	GOTO 8460																# skip to the distance calculation
8350 	IF A > 0 THEN															# if the x-axis distance is positive
8351 		C1 = 3																	# adjust the starting direction pointing up
8352 		GOTO 8420																# skip to the up/down direction calculator
8353 	IFEND
8360 	IF X <> 0 THEN															# if the y-axis distance is not zero
8361 		C1 = 5																	# adjust the starting direction pointing left
8362 		GOTO 8290																# skip to the left/right direction calculator
8363 	IFEND
8410 	C1 = 7																	# adjust the starting direction pointing down
8420 	IF ABS(A) >= ABS(X) THEN 8450											# if the abs(y-axis distance) is not less than the abs(x-axis distance), adjust a fractional amount counter-clockwise
8430 	PRINT "DIRECTION =";C1 +(((ABS(X) - ABS(A)) + ABS(X)) / ABS(X))			# otherwise, adjust a grosser amount counter-clockwise
8431 	GOTO 8460																# skip to the distance calculator
8450 	PRINT "DIRECTION =";C1 + (ABS(X) / ABS(A))								# calculate the fractional amount counter-clockwise
8460 	PRINT "DISTANCE =";SQR(X ^ 2 + A ^ 2)									# calculate the distance between the two sectors
	8461 	IF H8 = 1 THEN 1990														# if we're displaying the quadrant sector details, go try for another command
	8480 NEXT I
	8481 GOTO 1990																# try for another command
	8500 IF B3 <> 0 THEN														# if there's a starbase in the quadrant
	8501 	PRINT "FROM ENTERPRISE TO STARBASE:"									# get it's sector coordinates
8502 	W1 = B4
8503 	X = B5
8504 	GOTO 8120																# calculate its direction and distance
	8505 IFEND
	8510 PRINT "MR. SPOCK REPORTS,  'SENSORS SHOW NO STARBASES IN THIS";		# otherwise, report there are no starbases in the quadrant
	8520 PRINT " QUADRANT.'"
	8521 GOTO 1990																# try for another command
8580 REM FIND EMPTY PLACE IN QUADRANT (FOR THINGS)
8590 R1 = FNR(1)															# calculate a random sector in the quadrant
8591 R2 = FNR(1)
8592 A$ = "   "																# check if it is empty
8593 Z1 = R1
8594 Z2 = R2
8595 GOSUB 8830
8596 IF Z3 = 0 THEN 8590													# if it isn't empty, try another random sector in the quadrant
8600 RETURN
8660 REM INSERT IN STRING ARRAY FOR QUADRANT
8670 S8 = INT(Z2 - .5) * 3 + INT(Z1 - .5) * 24 + 1							# calculate what character in the quadrant string to start overwriting at, based on location provided
8675 IF LEN(A$) <> 3 THEN													# barf if the identifier to insert isn't 3 characters
8676 	PRINT "ERROR"
8677 	STOP																	# kick out of the program --> exception
8678 IFEND
8680 IF S8 = 1 THEN															# if it's to go at the start of the string, add it in front of the rightmost 189 characters
8681 	Q$ = A$ + RIGHT$(Q$, 189)
8682 	RETURN
8683 IFEND
8690 IF S8 = 190 THEN														# if it's to go at the end of the string, add it to the end of leftmost 189 characters
8691 	Q$ = LEFT$(Q$, 189) + A$
8692 	RETURN
8693 IFEND
8700 Q$ = LEFT$(Q$, S8 - 1) + A$ + RIGHT$(Q$, 190 - S8)						# if it's somewhere in the middle, add it in between the parts surrounding it
8701 RETURN
	8780 REM PRINTS DEVICE NAME
	8790 ON R1 GOTO 8792, 8794, 8796, 8798, 8800, 8802, 8804, 8806
	8792 G2$ = "WARP ENGINES"
	8793 RETURN
	8794 G2$ = "SHORT RANGE SENSORS"
	8795 RETURN
	8796 G2$ = "LONG RANGE SENSORS"
	8797 RETURN
	8798 G2$ = "PHASER CONTROL"
	8799 RETURN
	8800 G2$ = "PHOTON TUBES"
	8801 RETURN
	8802 G2$ = "DAMAGE CONTROL"
	8803 RETURN
	8804 G2$ = "SHIELD CONTROL"
	8805 RETURN
	8806 G2$ = "LIBRARY-COMPUTER"
	8807 RETURN
	8820 REM STRING COMPARISON IN QUADRANT ARRAY								# check if the specified sector is set to the value in A$
	8830 Z1 = INT(Z1 + .5)														# round the provided quadrant sector coordinates
	8831 Z2 = INT(Z2 + .5)
	8832 S8 = (Z2 - 1) * 3 + (Z1 - 1) * 24 + 1									# calculate the starting position of the 3 character string to check
	8834 Z3 = 0																	# set the return flag to 0 (false)
	8890 IF MID$(Q$, S8, 3) <> A$ THEN RETURN									# if the sector contains something that isn't A$, return
	8900 Z3 = 1																	# the sector contains the value in A$, so set the return flag to 1 (true), and return
	8901 RETURN
	9010 REM QUADRANT NAME IN G2$ FROM Z4,Z5 (=Q1,Q2)
	9020 REM CALL WITH G5=1 TO GET REGION NAME ONLY
	9030 IF Z5 <= 4 THEN ON Z4 GOTO 9040, 9050, 9060, 9070, 9080, 9090, 9100, 9110
	9035 GOTO 9120
	9040 G2$ = "ANTARES"
	9041 GOTO 9210
	9050 G2$ = "RIGEL"
	9051 GOTO 9210
	9060 G2$ = "PROCYON"
	9061 GOTO 9210
	9070 G2$ = "VEGA"
	9071 GOTO 9210
	9080 G2$ = "CANOPUS"
	9081 GOTO 9210
	9090 G2$ = "ALTAIR"
	9091 GOTO 9210
	9100 G2$ = "SAGITTARIUS"
	9101 GOTO 9210
	9110 G2$ = "POLLUX"
	9111 GOTO 9210
	9120 ON Z4 GOTO 9130, 9140, 9150, 9160, 9170, 9180, 9190, 9200
	9130 G2$ = "SIRIUS"
	9131 GOTO 9210
	9140 G2$ = "DENEB"
	9141 GOTO 9210
	9150 G2$ = "CAPELLA"
	9151 GOTO 9210
	9160 G2$ = "BETELGEUSE"
	9161 GOTO 9210
	9170 G2$ = "ALDEBARAN"
	9171 GOTO 9210
	9180 G2$ = "REGULUS"
	9181 GOTO 9210
	9190 G2$ = "ARCTURUS"
	9191 GOTO 9210
	9200 G2$ = "SPICA"
	9210 IF G5 <> 1 THEN ON Z5 GOTO 9230, 9240, 9250, 9260, 9230, 9240, 9250, 9260
	9220 RETURN
	9230 G2$ = G2$ + " I"
	9231 RETURN
	9240 G2$ = G2$ + " II"
	9241 RETURN
	9250 G2$ = G2$ + " III"
	9251 RETURN
	9260 G2$ = G2$ + " IV"
	9261 RETURN
