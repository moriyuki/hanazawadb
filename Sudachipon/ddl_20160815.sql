-- Project Name : noname
-- Date/Time    : 2016/08/15 21:48:17
-- Author       : Noriyuki Takakura
-- RDBMS Type   : Oracle Database
-- Application  : A5:SQL Mk-2

-- dt_pc_user_date
drop table NEW_ENTITY1 cascade constraint;

create table NEW_ENTITY1 (
  pud_date date
  , pud_pc_id integer not null
  , pud_user_id integer not null
  , constraint NEW_ENTITY1_PKC primary key (pud_date,pud_pc_id,pud_user_id)
) ;

-- dt_pc_soft	 pcとsoftの関係を管理
drop table dt_pc_soft cascade constraint;

create table dt_pc_soft (
  ps_pc_id integer not null
  , ps_soft_id integer not null
  , ps_comment character varying
  , constraint dt_pc_soft_PKC primary key (ps_pc_id,ps_soft_id)
) ;

-- dt_user_date	 利用者と出勤日の関係を管理
drop table dt_user_date cascade constraint;

create table dt_user_date (
  ud_user_id integer not null
  , ud_date date default ('now'::text) not null
  , ud_comment character varying
  , constraint dt_user_date_PKC primary key (ud_user_id,ud_date)
) ;

-- dt_user_soft	 ユーザとソフトの関係を管理
drop table dt_user_soft cascade constraint;

create table dt_user_soft (
  usf_user_id integer not null
  , usf_soft_id integer not null
  , usf_comment character varying
  , constraint dt_user_soft_PKC primary key (usf_user_id,usf_soft_id)
) ;

-- mt_pc	 pc管理マスタテーブル
drop table mt_pc cascade constraint;

create table mt_pc (
  pc_id integer not null
  , pc_name character varying
  , pc_os character varying
  , pc_memory character varying
  , pc_cpu character varying
  , pc_active boolean default 't' not null
  , pc_is_byod boolean default 'f' not null
  , pc_comment character varying
  , constraint mt_pc_PKC primary key (pc_id)
) ;

-- mt_soft	 ソフトウェア管理マスタテーブル
drop table mt_soft cascade constraint;

create table mt_soft (
  sf_id integer not null
  , sf_name character varying
  , sf_version character varying
  , sf_os integer default 1
  , sf_avilable_number integer default 1
  , sf_active boolean default 't' not null
  , sf_comment character varying
  , constraint mt_soft_PKC primary key (sf_id)
) ;

-- mt_user	 利用者、管理者情報管理テーブル
drop table mt_user cascade constraint;

create table mt_user (
  us_id integer not null
  , us_name character varying
  , us_type integer default 1
  , us_active boolean default 't' not null
  , us_comment character varying
  , constraint mt_user_PKC primary key (us_id)
) ;

comment on table NEW_ENTITY1 is 'dt_pc_user_date';
comment on column NEW_ENTITY1.pud_date is 'pud_date';
comment on column NEW_ENTITY1.pud_pc_id is 'pud_pc_id';
comment on column NEW_ENTITY1.pud_user_id is 'pud_user_id';

comment on table dt_pc_soft is 'dt_pc_soft	 pcとsoftの関係を管理';
comment on column dt_pc_soft.ps_pc_id is 'ps_pc_id	 pc内部ID';
comment on column dt_pc_soft.ps_soft_id is 'ps_soft_id	 soft内部ID';
comment on column dt_pc_soft.ps_comment is 'ps_comment	 備考';

comment on table dt_user_date is 'dt_user_date	 利用者と出勤日の関係を管理';
comment on column dt_user_date.ud_user_id is 'ud_user_id	 ユーザ内部ID';
comment on column dt_user_date.ud_date is 'ud_date	 出勤日';
comment on column dt_user_date.ud_comment is 'ud_comment	 コメント';

comment on table dt_user_soft is 'dt_user_soft	 ユーザとソフトの関係を管理';
comment on column dt_user_soft.usf_user_id is 'usf_user_id	 ユーザ内部ID';
comment on column dt_user_soft.usf_soft_id is 'usf_soft_id	 ソフトウェア内部ID';
comment on column dt_user_soft.usf_comment is 'usf_comment	 備考';

comment on table mt_pc is 'mt_pc	 pc管理マスタテーブル';
comment on column mt_pc.pc_id is 'pc_id	 内部ID';
comment on column mt_pc.pc_name is 'pc_name	 PCに張られている名前';
comment on column mt_pc.pc_os is 'pc_os	 PCのOS';
comment on column mt_pc.pc_memory is 'pc_memory	 PCのメモリ';
comment on column mt_pc.pc_cpu is 'pc_cpu	 PCのCPU';
comment on column mt_pc.pc_active is 'pc_active';
comment on column mt_pc.pc_is_byod is 'pc_is_byod';
comment on column mt_pc.pc_comment is 'pc_comment	 備考';

comment on table mt_soft is 'mt_soft	 ソフトウェア管理マスタテーブル';
comment on column mt_soft.sf_id is 'sf_id	 内部ID';
comment on column mt_soft.sf_name is 'sf_name	 ソフトウェア名称';
comment on column mt_soft.sf_version is 'sf_version	 ソフトウェアバージョン';
comment on column mt_soft.sf_os is 'sf_os	 !:win, 2:mac, 3:win&mac';
comment on column mt_soft.sf_avilable_number is 'sf_avilable_number	 利用可能台数';
comment on column mt_soft.af_active is 'sf_active';
comment on column mt_soft.sf_comment is 'sf_comment	 備考';

comment on table mt_user is 'mt_user	 利用者、管理者情報管理テーブル';
comment on column mt_user.us_id is 'us_id	 内部ID';
comment on column mt_user.us_name is 'us_name	 氏名';
comment on column mt_user.us_type is 'us_type	 1:利用者, ２：管理者';
comment on column mt_user.us_active is 'us_active';
comment on column mt_user.us_comment is 'us_comment	 備考';

