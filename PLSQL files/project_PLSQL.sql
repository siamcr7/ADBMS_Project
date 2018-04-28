--- Top Scorer IN a Team
create or replace procedure findTopPlayerOfTeam(team_name teams.teamname%type, player_name out players.playername%type, goal_scored out players.goalscored%type) 
is
	team_id teams.teamid%type := -1;
	cursor cur_team is
		select * from teams;
		
	cursor cur_player is
		select * from players
		where teamid = team_id
		order by goalscored;
begin
	
	FOR rec_team in cur_team
	loop
	
		if (rec_team.teamname = team_name) then
			team_id := rec_team.teamid;
			exit;
		end if;
		
	end loop;
	
	FOR rec_player in cur_player
	loop
	
		player_name := rec_player.playername;
		goal_scored := rec_player.goalscored;
		
		exit;
	end loop;
	
	if (goal_scored = null) then
		goal_scored := 0;
	end if;
	
	if(team_id = -1)then
		player_name := 'NOTHING!';
		goal_scored := 0;
	end if;
	
end;
/

declare
	player_name players.playername%type;
	goal_scored players.goalscored%type;
begin
	findTopPlayerOfTeam('CHELSEA',player_name,goal_scored);
	dbms_output.put_line(player_name);
	dbms_output.put_line(goal_scored);
end;


--- best player in position
create or replace procedure findBestPlayerPos(pos_name positions.pos%type, player_name out players.playername%type, goal_scored out players.goalscored%type, assists out players.assists%type, saves out players.saves%type) 
is
	cursor cur_pos is
		select playername,goalscored,assists,saves from players,positions
		where 
		positions.playerid = players.playerid
		and
		positions.pos like  '%'|| pos_name || '%';
		
	rec_pos cur_pos%ROWTYPE;
	totCount int := 0;
	
begin
	
	totCount := 0;
	goal_scored := 0;
	saves := 0;
	assists := 0;
	player_name := 'NOTHING!';
	
	open cur_pos;
	
	loop
		fetch cur_pos into rec_pos;
		if(cur_pos%notfound) then
			exit;
		end if;
		
		
		if( ( nvl(rec_pos.goalscored,0) + nvl(rec_pos.assists,0) + nvl(rec_pos.saves,0)) > totCount) then
			goal_scored := nvl(rec_pos.goalscored,0);
			assists := nvl(rec_pos.assists,0);
			saves := nvl(rec_pos.saves,0);
			player_name := rec_pos.playername;
			totCount := ( nvl(rec_pos.goalscored,0) + nvl(rec_pos.assists,0) + nvl(rec_pos.saves,0));
		end if;
		
	end loop;
	
	close cur_pos;
	
end;
/

declare
	player_name players.playername%type;
	goal_scored players.goalscored%type;
	assists players.assists%type;
	saves players.saves%type;
begin
	findBestPlayerPos('STRIKER',player_name,goal_scored,assists,saves);
	dbms_output.put_line(player_name);
	dbms_output.put_line(goal_scored);
	dbms_output.put_line(assists);
	dbms_output.put_line(saves);
end;



-- PL Standings
create or replace procedure seeStandings(team_name out varchar2, points out varchar2) 
is
	cursor cur_pos is
		select teamname, (gamewon*3) + gamedrawn POINTS
		from teams
		order by POINTS desc;
		
	rec_pos cur_pos%ROWTYPE;
	
begin
	
	team_name := '';
	points  := '';
	
	open cur_pos;
	
	loop
		fetch cur_pos into rec_pos;
		if(cur_pos%notfound) then
			exit;
		end if;
		
		team_name := team_name || rec_pos.teamname;
		team_name := team_name || ',';
		
		points := points || rec_pos.POINTS;
		points := points || ',';
		
	end loop;
	
	close cur_pos;
	
end;
/

declare
	team_name varchar2(1000);
	points varchar2(1000);
begin
	seeStandings(team_name,points);
	dbms_output.put_line(team_name);
	dbms_output.put_line(points);
end;




--- Package: For Report
--- Package Starts
--- package specifications
create or replace package pack_report as
	
	-- PL Standing
	procedure seeStandingsProc(team_name out varchar2, points out varchar2);
	
	
	-- Best Player in Position
	procedure findBestPlayerPosProc(pos_name positions.pos%type, player_name out players.playername%type, goal_scored out players.goalscored%type, assists out players.assists%type, saves out players.saves%type);
	
	
end pack_report;


--- package Body
create or replace package body pack_report as
	
	-- PL Standing
	procedure seeStandingsProc(team_name out varchar2, points out varchar2) 
	is
		cursor cur_pos is
			select teamname, (gamewon*3) + gamedrawn POINTS
			from teams
			order by POINTS desc;
			
		rec_pos cur_pos%ROWTYPE;
		
	begin
		
		team_name := '';
		points  := '';
		
		open cur_pos;
		
		loop
			fetch cur_pos into rec_pos;
			if(cur_pos%notfound) then
				exit;
			end if;
			
			team_name := team_name || rec_pos.teamname;
			team_name := team_name || ',';
			
			points := points || rec_pos.POINTS;
			points := points || ',';
			
		end loop;
		
		close cur_pos;
		
	end seeStandingsProc;
	
	
	-- Best Player in Position
	procedure findBestPlayerPosProc(pos_name positions.pos%type, player_name out players.playername%type, goal_scored out players.goalscored%type, assists out players.assists%type, saves out players.saves%type) 
	is
		cursor cur_pos is
			select playername,goalscored,assists,saves from players,positions
			where 
			positions.playerid = players.playerid
			and
			positions.pos like  '%'|| pos_name || '%';
			
		rec_pos cur_pos%ROWTYPE;
		totCount int := 0;
		
	begin
		
		totCount := 0;
		goal_scored := 0;
		saves := 0;
		assists := 0;
		player_name := 'NOTHING!';
		
		open cur_pos;
		
		loop
			fetch cur_pos into rec_pos;
			if(cur_pos%notfound) then
				exit;
			end if;
			
			
			if( ( nvl(rec_pos.goalscored,0) + nvl(rec_pos.assists,0) + nvl(rec_pos.saves,0)) > totCount) then
				goal_scored := nvl(rec_pos.goalscored,0);
				assists := nvl(rec_pos.assists,0);
				saves := nvl(rec_pos.saves,0);
				player_name := rec_pos.playername;
				totCount := ( nvl(rec_pos.goalscored,0) + nvl(rec_pos.assists,0) + nvl(rec_pos.saves,0));
			end if;
			
		end loop;
		
		close cur_pos;
		
	end findBestPlayerPosProc;
	
end pack_report;
/



--- Trigger Logs
--- Log updates in player name and goal scored
create or replace trigger log_update_player_name
after update
of playername,goalscored
on players
for each row
begin
	insert into log_update_player_name (new_name, old_name, new_goal, old_goal) values(:new.playername, :old.playername, :new.goalscored, :old.goalscored);
end;


--- goal check throw error
create or replace trigger goal_check 
before update 
of goalscored
on players 
for each row
begin
	if(:old.goalscored > :new.goalscored)then
	-- action is blocked! 
	raise_application_error(-20101, 'New Goal Count can not be less than old Goals Count!!');
	end if;
end;


--- when a new team is inserted, create a log
create or replace trigger log_insert_teams
after insert
on teams
for each row
begin
	insert into log_insert_teams (new_team_id, new_team_name, time_of_insert) values(:new.teamid, :new.teamname, sysdate);
end;

CREATE OR REPLACE TRIGGER  "UPDATE_JOB_HISTORY" 
	AFTER UPDATE 
	OF job_id, department_id 
	ON employees
	FOR EACH ROW
BEGIN
	-- a new procedure is creted! 
	add_job_history
	(
		:old.employee_id, :old.hire_date, sysdate,:old.job_id, :old.department_id
	);
END;


--- Function to get new id
create or replace procedure getNextID(table_name in varchar2, nextID out int) 
is
begin
	
	nextID := -1;
	if(table_name = 'players') then
		select max(playerid) into nextID from players;
		
	elsif(table_name = 'coaches') then
		select max(coachid) into nextID from coaches;
		
	elsif(table_name = 'teams') then
		select max(teamid) into nextID from teams;
		
	end if;
	
	nextID := nextID + 1;
end;
/

declare
	nextID int;
begin
	getNextID('players',nextID);
	dbms_output.put_line(nextID);
end;




--- advanced search
select * from players
where
playername like '%%'
and 
teamid in 
(
	select teamid from teams
	where 
	teamname like '%A%'
	and
	ownerid in
	(
		select ownerid from owners
		where ownername like '%A%'
	)
	and 
	kitid in
	(
		select kitid from kits
		where kitcolor like '%%'
	)
)
and
sponsorid in
(
	select sponsorid from sponsors
	where 
	sponsorname like '%%'
)
and
locid in
(
	select locid from locations
	where 
	loc like '%A%'
)
and 
nvl(goalscored,0) between 0 and 100
and 
nvl(saves,0) between 0 and 100
and 
nvl(assists,0) between 0 and 100
;