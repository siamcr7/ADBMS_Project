CREATE TABLE  "USERS" (	
USER_ID NUMBER(5,0) NOT NULL ENABLE, 
USER_NAME VARCHAR2(4000), 
PASSWORD VARCHAR2(4000)
)

LOCATIONS table:
CREATE TABLE LOCATIONS (
LOCID NUMBER (2),
CONSTRAINT LOCATIONS_LOCID_PK PRIMARY KEY(LOCID),
LOC VARCHAR2 (12)
)

KITS table:
CREATE TABLE KITS(
KITID NUMBER (2),
CONSTRAINT KITS_KITID_PK PRIMARY KEY(KITID),
KITCOLOR VARCHAR2 (12)
)

STADIUM table:
CREATE TABLE STADIUM(
STADIUMID NUMBER (2),
CONSTRAINT STADIUM_STADIUMID_PK PRIMARY KEY(STADIUMID),
STADIUMNAME VARCHAR2 (30),
LOCID NUMBER (2),
CONSTRAINT STADIUM_LOCID_FK FOREIGN KEY (LOCID)
REFERENCES LOCATIONS (LOCID),
CAPACITY NUMBER (15)
)

OWNERS table:
CREATE TABLE OWNERS(
OWNERID NUMBER (2),
CONSTRAINT OWNERS_OWNERID_PK PRIMARY KEY(OWNERID),
OWNERNAME VARCHAR2 (15),
LOCID NUMBER (2),
CONSTRAINT OWNERS_LOCID_FK FOREIGN KEY (LOCID)
REFERENCES LOCATIONS (LOCID)
)

COACHES table:
CREATE TABLE COACHES(
COACHID NUMBER (2),
CONSTRAINT COACHES_COACHID_PK PRIMARY KEY(COACHID),
COACHNAME VARCHAR2 (15),
LOCID NUMBER (2),
CONSTRAINT COACHES_LOCID_FK FOREIGN KEY (LOCID)
REFERENCES LOCATIONS (LOCID)
)
SPONSORS table:
CREATE TABLE SPONSORS(
SPONSORID NUMBER (2),
CONSTRAINT SPONSORS_SPONSORID_PK PRIMARY KEY(SPONSORID),
SPONSORNAME VARCHAR2 (15),
LOCID NUMBER (2),
CONSTRAINT SPONSORS_LOCID_FK FOREIGN KEY (LOCID)
REFERENCES LOCATIONS (LOCID),
OWNERID NUMBER(2),
CONSTRAINT SPONSORS_OWNERID_FK FOREIGN KEY (OWNERID)
REFERENCES OWNERS (OWNERID)
)

TEAMS table:
CREATE TABLE TEAMS(
TEAMID NUMBER (2),
CONSTRAINT TEAMS_TEAMID_PK PRIMARY KEY(TEAMID),
TEAMNAME VARCHAR2 (15),
STADIUMID NUMBER (2),
CONSTRAINT TEAMS_STADIUMID_FK FOREIGN KEY (STADIUMID)
REFERENCES STADIUM (STADIUMID),
COACHID NUMBER (2),
CONSTRAINT TEAMS_COACHID_FK FOREIGN KEY (COACHID)
REFERENCES COACHES (COACHID),
GAMEPLAYED NUMBER (3),
GAMEWON NUMBER (3),
GAMELOST NUMBER (3),
GAMEDRAWN NUMBER (3),
SPONSORID NUMBER(2),
CONSTRAINT TEAMS_SPONSORID_FK FOREIGN KEY (SPONSORID)
REFERENCES SPONSORS (SPONSORID),
KITID NUMBER(2),
CONSTRAINT TEAMS_KITID_FK FOREIGN KEY (KITID)
REFERENCES KITS (KITID),
OWNERID NUMBER(2),
CONSTRAINT TEAMS_OWNERID_FK FOREIGN KEY (OWNERID)
REFERENCES OWNERS (OWNERID)
)

PLAYERS table:
CREATE TABLE PLAYERS(
PLAYERID NUMBER (2),
CONSTRAINT PLAYERS_PLAYERID_PK PRIMARY KEY(PLAYERID),
PLAYERNAME VARCHAR2 (12),
DOB DATE,
LOCID NUMBER (2),
CONSTRAINT PLAYERS_LOCID_FK FOREIGN KEY (LOCID)
REFERENCES LOCATIONS (LOCID),
GOALSCORED NUMBER (3),
ASSISTS NUMBER (3),
SAVES NUMBER (3),
TEAMID NUMBER(2),
CONSTRAINT PLAYERS_TEAMID_FK FOREIGN KEY (TEAMID)
REFERENCES TEAMS (TEAMID),
SPONSORID NUMBER(2),
CONSTRAINT PLAYERS_SPONSORID_FK FOREIGN KEY (SPONSORID)
REFERENCES SPONSORS (SPONSORID)
)

POSITIONS table:
CREATE TABLE POSITIONS(
PLAYERID NUMBER(2),
CONSTRAINT POSITIONS_PLAYERID_FK FOREIGN KEY (PLAYERID)
REFERENCES PLAYERS (PLAYERID),
POS VARCHAR2 (20)
)
