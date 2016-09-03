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

-- dt_pc_soft	 pc��soft�̊֌W���Ǘ�
drop table dt_pc_soft cascade constraint;

create table dt_pc_soft (
  ps_pc_id integer not null
  , ps_soft_id integer not null
  , ps_comment character varying
  , constraint dt_pc_soft_PKC primary key (ps_pc_id,ps_soft_id)
) ;

-- dt_user_date	 ���p�҂Əo�Γ��̊֌W���Ǘ�
drop table dt_user_date cascade constraint;

create table dt_user_date (
  ud_user_id integer not null
  , ud_date date default ('now'::text) not null
  , ud_comment character varying
  , constraint dt_user_date_PKC primary key (ud_user_id,ud_date)
) ;

-- dt_user_soft	 ���[�U�ƃ\�t�g�̊֌W���Ǘ�
drop table dt_user_soft cascade constraint;

create table dt_user_soft (
  usf_user_id integer not null
  , usf_soft_id integer not null
  , usf_comment character varying
  , constraint dt_user_soft_PKC primary key (usf_user_id,usf_soft_id)
) ;

-- mt_pc	 pc�Ǘ��}�X�^�e�[�u��
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

-- mt_soft	 �\�t�g�E�F�A�Ǘ��}�X�^�e�[�u��
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

-- mt_user	 ���p�ҁA�Ǘ��ҏ��Ǘ��e�[�u��
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

comment on table dt_pc_soft is 'dt_pc_soft	 pc��soft�̊֌W���Ǘ�';
comment on column dt_pc_soft.ps_pc_id is 'ps_pc_id	 pc����ID';
comment on column dt_pc_soft.ps_soft_id is 'ps_soft_id	 soft����ID';
comment on column dt_pc_soft.ps_comment is 'ps_comment	 ���l';

comment on table dt_user_date is 'dt_user_date	 ���p�҂Əo�Γ��̊֌W���Ǘ�';
comment on column dt_user_date.ud_user_id is 'ud_user_id	 ���[�U����ID';
comment on column dt_user_date.ud_date is 'ud_date	 �o�Γ�';
comment on column dt_user_date.ud_comment is 'ud_comment	 �R�����g';

comment on table dt_user_soft is 'dt_user_soft	 ���[�U�ƃ\�t�g�̊֌W���Ǘ�';
comment on column dt_user_soft.usf_user_id is 'usf_user_id	 ���[�U����ID';
comment on column dt_user_soft.usf_soft_id is 'usf_soft_id	 �\�t�g�E�F�A����ID';
comment on column dt_user_soft.usf_comment is 'usf_comment	 ���l';

comment on table mt_pc is 'mt_pc	 pc�Ǘ��}�X�^�e�[�u��';
comment on column mt_pc.pc_id is 'pc_id	 ����ID';
comment on column mt_pc.pc_name is 'pc_name	 PC�ɒ����Ă��閼�O';
comment on column mt_pc.pc_os is 'pc_os	 PC��OS';
comment on column mt_pc.pc_memory is 'pc_memory	 PC�̃�����';
comment on column mt_pc.pc_cpu is 'pc_cpu	 PC��CPU';
comment on column mt_pc.pc_active is 'pc_active';
comment on column mt_pc.pc_is_byod is 'pc_is_byod';
comment on column mt_pc.pc_comment is 'pc_comment	 ���l';

comment on table mt_soft is 'mt_soft	 �\�t�g�E�F�A�Ǘ��}�X�^�e�[�u��';
comment on column mt_soft.sf_id is 'sf_id	 ����ID';
comment on column mt_soft.sf_name is 'sf_name	 �\�t�g�E�F�A����';
comment on column mt_soft.sf_version is 'sf_version	 �\�t�g�E�F�A�o�[�W����';
comment on column mt_soft.sf_os is 'sf_os	 !:win, 2:mac, 3:win&mac';
comment on column mt_soft.sf_avilable_number is 'sf_avilable_number	 ���p�\�䐔';
comment on column mt_soft.af_active is 'sf_active';
comment on column mt_soft.sf_comment is 'sf_comment	 ���l';

comment on table mt_user is 'mt_user	 ���p�ҁA�Ǘ��ҏ��Ǘ��e�[�u��';
comment on column mt_user.us_id is 'us_id	 ����ID';
comment on column mt_user.us_name is 'us_name	 ����';
comment on column mt_user.us_type is 'us_type	 1:���p��, �Q�F�Ǘ���';
comment on column mt_user.us_active is 'us_active';
comment on column mt_user.us_comment is 'us_comment	 ���l';

