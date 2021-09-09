namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("SRSM002")]
public class SRSM002 
{
    [Required]
    public string name1 { get; set; }
    [Required]
    public string name2 { get; set; }
    [Required]
    public string text1 { get; set; }
    [Required]
    public string text2 { get; set; }
    [Required]
    public string addr1 { get; set; }
    [Required]
    public string addr2 { get; set; }
    [Required]
    public string addr3 { get; set; }
    [Required]
    public string branch { get; set; }
    [Required]
    public string idno { get; set; }
    [Required]
    public char? seq { get; set; }
    [Required]
    public string ded_amt { get; set; }
    [Required]
    public string acctno { get; set; }
    [Required]
    public string revolve_amt { get; set; }
    [Required]
    public string lastpaydate { get; set; }
    [Required]
    public string prev_tot_receivable { get; set; }
    [Required]
    public string prev_payment { get; set; }
    [Required]
    public string print_date { get; set; }
    [Required]
    public char? page { get; set; }
    [Required]
    public string o_amt { get; set; }
    [Required]
    public string pre_p_amt { get; set; }
    [Required]
    public string c_amt { get; set; }
    [Required]
    public string p_amt { get; set; }
    [Required]
    public string d_amt { get; set; }
    [Required]
    public string e_amt { get; set; }
    [Required]
    public string f_amt { get; set; }
    [Required]
    public string r_amt { get; set; }
    [Required]
    public string pay_amt { get; set; }
    [Required]
    public string min_pay_amt { get; set; }
    [Required]
    public string g1_msg { get; set; }
    [Required]
    public string g2_msg { get; set; }
    [Required]
    public string g3_msg { get; set; }
    [Required]
    public string g4_msg { get; set; }
    [Required]
    public string acct_yymm { get; set; }
    [Required]
    public string last_tot_dot { get; set; }
    [Required]
    public string curr_dot { get; set; }
    [Required]
    public string use_dot { get; set; }
    [Required]
    public string this_tot_dot { get; set; }
    [Required]
    public char? atm_acct_no { get; set; }
    [Required]
    public string acctno_bank { get; set; }
    [Required]
    public string public_amt { get; set; }
    [Required]
    public char? delq_flag { get; set; }
    [Required]
    public char? birth_flag { get; set; }
    [Required]
    public char? Other_flag { get; set; }
    [Required]
    public string pur_d01 { get; set; }
    [Required]
    public string acq_d01 { get; set; }
    [Required]
    public string des_c01 { get; set; }
    [Required]
    public string f_amt01 { get; set; }
    [Required]
    public string c_date01 { get; set; }
    [Required]
    public string p_amt01 { get; set; }
    [Required]
    public string pur_d02 { get; set; }
    [Required]
    public string acq_d02 { get; set; }
    [Required]
    public string des_c02 { get; set; }
    [Required]
    public string f_amt02 { get; set; }
    [Required]
    public string c_date02 { get; set; }
    [Required]
    public string p_amt02 { get; set; }
    [Required]
    public string pur_d03 { get; set; }
    [Required]
    public string acq_d03 { get; set; }
    [Required]
    public string des_c03 { get; set; }
    [Required]
    public string f_amt03 { get; set; }
    [Required]
    public string c_date03 { get; set; }
    [Required]
    public string p_amt03 { get; set; }
    [Required]
    public string pur_d04 { get; set; }
    [Required]
    public string acq_d04 { get; set; }
    [Required]
    public string des_c04 { get; set; }
    [Required]
    public string f_amt04 { get; set; }
    [Required]
    public string c_date04 { get; set; }
    [Required]
    public string p_amt04 { get; set; }
    [Required]
    public string pur_d05 { get; set; }
    [Required]
    public string acq_d05 { get; set; }
    [Required]
    public string des_c05 { get; set; }
    [Required]
    public string f_amt05 { get; set; }
    [Required]
    public string c_date05 { get; set; }
    [Required]
    public string p_amt05 { get; set; }
    [Required]
    public string pur_d06 { get; set; }
    [Required]
    public string acq_d06 { get; set; }
    [Required]
    public string des_c06 { get; set; }
    [Required]
    public string f_amt06 { get; set; }
    [Required]
    public string c_date06 { get; set; }
    [Required]
    public string p_amt06 { get; set; }
    [Required]
    public string pur_d07 { get; set; }
    [Required]
    public string acq_d07 { get; set; }
    [Required]
    public string des_c07 { get; set; }
    [Required]
    public string f_amt07 { get; set; }
    [Required]
    public string c_date07 { get; set; }
    [Required]
    public string p_amt07 { get; set; }
    [Required]
    public string pur_d08 { get; set; }
    [Required]
    public string acq_d08 { get; set; }
    [Required]
    public string des_c08 { get; set; }
    [Required]
    public string f_amt08 { get; set; }
    [Required]
    public string c_date08 { get; set; }
    [Required]
    public string p_amt08 { get; set; }
    [Required]
    public string pur_d09 { get; set; }
    [Required]
    public string acq_d09 { get; set; }
    [Required]
    public string des_c09 { get; set; }
    [Required]
    public string f_amt09 { get; set; }
    [Required]
    public string c_date09 { get; set; }
    [Required]
    public string p_amt09 { get; set; }
    [Required]
    public string pur_d10 { get; set; }
    [Required]
    public string acq_d10 { get; set; }
    [Required]
    public string des_c10 { get; set; }
    [Required]
    public string f_amt10 { get; set; }
    [Required]
    public string c_date10 { get; set; }
    [Required]
    public string p_amt10 { get; set; }
    [Required]
    public string pur_d11 { get; set; }
    [Required]
    public string acq_d11 { get; set; }
    [Required]
    public string des_c11 { get; set; }
    [Required]
    public string f_amt11 { get; set; }
    [Required]
    public string c_date11 { get; set; }
    [Required]
    public string p_amt11 { get; set; }
    [Required]
    public string pur_d12 { get; set; }
    [Required]
    public string acq_d12 { get; set; }
    [Required]
    public string des_c12 { get; set; }
    [Required]
    public string f_amt12 { get; set; }
    [Required]
    public string c_date12 { get; set; }
    [Required]
    public string p_amt12 { get; set; }
    [Required]
    public string pur_d13 { get; set; }
    [Required]
    public string acq_d13 { get; set; }
    [Required]
    public string des_c13 { get; set; }
    [Required]
    public string f_amt13 { get; set; }
    [Required]
    public string c_date13 { get; set; }
    [Required]
    public string p_amt13 { get; set; }
    [Required]
    public string pur_d14 { get; set; }
    [Required]
    public string acq_d14 { get; set; }
    [Required]
    public string des_c14 { get; set; }
    [Required]
    public string f_amt14 { get; set; }
    [Required]
    public string c_date14 { get; set; }
    [Required]
    public string p_amt14 { get; set; }
    [Required]
    public string pur_d15 { get; set; }
    [Required]
    public string acq_d15 { get; set; }
    [Required]
    public string des_c15 { get; set; }
    [Required]
    public string f_amt15 { get; set; }
    [Required]
    public string c_date15 { get; set; }
    [Required]
    public string p_amt15 { get; set; }
    [Required]
    public string pur_d16 { get; set; }
    [Required]
    public string acq_d16 { get; set; }
    [Required]
    public string des_c16 { get; set; }
    [Required]
    public string f_amt16 { get; set; }
    [Required]
    public string c_date16 { get; set; }
    [Required]
    public string p_amt16 { get; set; }
    [Required]
    public string pur_d17 { get; set; }
    [Required]
    public string acq_d17 { get; set; }
    [Required]
    public string des_c17 { get; set; }
    [Required]
    public string f_amt17 { get; set; }
    [Required]
    public string c_date17 { get; set; }
    [Required]
    public string p_amt17 { get; set; }
    [Required]
    public string pur_d18 { get; set; }
    [Required]
    public string acq_d18 { get; set; }
    [Required]
    public string des_c18 { get; set; }
    [Required]
    public string f_amt18 { get; set; }
    [Required]
    public string c_date18 { get; set; }
    [Required]
    public string p_amt18 { get; set; }
    [Required]
    public string pur_d19 { get; set; }
    [Required]
    public string acq_d19 { get; set; }
    [Required]
    public string des_c19 { get; set; }
    [Required]
    public string f_amt19 { get; set; }
    [Required]
    public string c_date19 { get; set; }
    [Required]
    public string p_amt19 { get; set; }
    [Required]
    public string pur_d20 { get; set; }
    [Required]
    public string acq_d20 { get; set; }
    [Required]
    public string des_c20 { get; set; }
    [Required]
    public string f_amt20 { get; set; }
    [Required]
    public string c_date20 { get; set; }
    [Required]
    public string p_amt20 { get; set; }
    [Required]
    public string pur_d21 { get; set; }
    [Required]
    public string acq_d21 { get; set; }
    [Required]
    public string des_c21 { get; set; }
    [Required]
    public string f_amt21 { get; set; }
    [Required]
    public string c_date21 { get; set; }
    [Required]
    public string p_amt21 { get; set; }
    [Required]
    public string pur_d22 { get; set; }
    [Required]
    public string acq_d22 { get; set; }
    [Required]
    public string des_c22 { get; set; }
    [Required]
    public string f_amt22 { get; set; }
    [Required]
    public string c_date22 { get; set; }
    [Required]
    public string p_amt22 { get; set; }
    [Required]
    public string pur_d23 { get; set; }
    [Required]
    public string acq_d23 { get; set; }
    [Required]
    public string des_c23 { get; set; }
    [Required]
    public string f_amt23 { get; set; }
    [Required]
    public string c_date23 { get; set; }
    [Required]
    public string p_amt23 { get; set; }
    [Required]
    public string pur_d24 { get; set; }
    [Required]
    public string acq_d24 { get; set; }
    [Required]
    public string des_c24 { get; set; }
    [Required]
    public string f_amt24 { get; set; }
    [Required]
    public string c_date24 { get; set; }
    [Required]
    public string p_amt24 { get; set; }
    [Required]
    public string pur_d25 { get; set; }
    [Required]
    public string acq_d25 { get; set; }
    [Required]
    public string des_c25 { get; set; }
    [Required]
    public string f_amt25 { get; set; }
    [Required]
    public string c_date25 { get; set; }
    [Required]
    public string p_amt25 { get; set; }
    [Required]
    public char? Status { get; set; }
    [Required]
    public char? Int_Rec { get; set; }

    public void Copy(SRSM002 src)
    {
        this.name1 = src.name1;
        this.name2 = src.name2;
        this.text1 = src.text1;
        this.text2 = src.text2;
        this.addr1 = src.addr1;
        this.addr2 = src.addr2;
        this.addr3 = src.addr3;
        this.branch = src.branch;
        this.idno = src.idno;
        this.seq = src.seq;
        this.ded_amt = src.ded_amt;
        this.acctno = src.acctno;
        this.revolve_amt = src.revolve_amt;
        this.lastpaydate = src.lastpaydate;
        this.prev_tot_receivable = src.prev_tot_receivable;
        this.prev_payment = src.prev_payment;
        this.print_date = src.print_date;
        this.page = src.page;
        this.o_amt = src.o_amt;
        this.pre_p_amt = src.pre_p_amt;
        this.c_amt = src.c_amt;
        this.p_amt = src.p_amt;
        this.d_amt = src.d_amt;
        this.e_amt = src.e_amt;
        this.f_amt = src.f_amt;
        this.r_amt = src.r_amt;
        this.pay_amt = src.pay_amt;
        this.min_pay_amt = src.min_pay_amt;
        this.g1_msg = src.g1_msg;
        this.g2_msg = src.g2_msg;
        this.g3_msg = src.g3_msg;
        this.g4_msg = src.g4_msg;
        this.acct_yymm = src.acct_yymm;
        this.last_tot_dot = src.last_tot_dot;
        this.curr_dot = src.curr_dot;
        this.use_dot = src.use_dot;
        this.this_tot_dot = src.this_tot_dot;
        this.atm_acct_no = src.atm_acct_no;
        this.acctno_bank = src.acctno_bank;
        this.public_amt = src.public_amt;
        this.delq_flag = src.delq_flag;
        this.birth_flag = src.birth_flag;
        this.Other_flag = src.Other_flag;
        this.pur_d01 = src.pur_d01;
        this.acq_d01 = src.acq_d01;
        this.des_c01 = src.des_c01;
        this.f_amt01 = src.f_amt01;
        this.c_date01 = src.c_date01;
        this.p_amt01 = src.p_amt01;
        this.pur_d02 = src.pur_d02;
        this.acq_d02 = src.acq_d02;
        this.des_c02 = src.des_c02;
        this.f_amt02 = src.f_amt02;
        this.c_date02 = src.c_date02;
        this.p_amt02 = src.p_amt02;
        this.pur_d03 = src.pur_d03;
        this.acq_d03 = src.acq_d03;
        this.des_c03 = src.des_c03;
        this.f_amt03 = src.f_amt03;
        this.c_date03 = src.c_date03;
        this.p_amt03 = src.p_amt03;
        this.pur_d04 = src.pur_d04;
        this.acq_d04 = src.acq_d04;
        this.des_c04 = src.des_c04;
        this.f_amt04 = src.f_amt04;
        this.c_date04 = src.c_date04;
        this.p_amt04 = src.p_amt04;
        this.pur_d05 = src.pur_d05;
        this.acq_d05 = src.acq_d05;
        this.des_c05 = src.des_c05;
        this.f_amt05 = src.f_amt05;
        this.c_date05 = src.c_date05;
        this.p_amt05 = src.p_amt05;
        this.pur_d06 = src.pur_d06;
        this.acq_d06 = src.acq_d06;
        this.des_c06 = src.des_c06;
        this.f_amt06 = src.f_amt06;
        this.c_date06 = src.c_date06;
        this.p_amt06 = src.p_amt06;
        this.pur_d07 = src.pur_d07;
        this.acq_d07 = src.acq_d07;
        this.des_c07 = src.des_c07;
        this.f_amt07 = src.f_amt07;
        this.c_date07 = src.c_date07;
        this.p_amt07 = src.p_amt07;
        this.pur_d08 = src.pur_d08;
        this.acq_d08 = src.acq_d08;
        this.des_c08 = src.des_c08;
        this.f_amt08 = src.f_amt08;
        this.c_date08 = src.c_date08;
        this.p_amt08 = src.p_amt08;
        this.pur_d09 = src.pur_d09;
        this.acq_d09 = src.acq_d09;
        this.des_c09 = src.des_c09;
        this.f_amt09 = src.f_amt09;
        this.c_date09 = src.c_date09;
        this.p_amt09 = src.p_amt09;
        this.pur_d10 = src.pur_d10;
        this.acq_d10 = src.acq_d10;
        this.des_c10 = src.des_c10;
        this.f_amt10 = src.f_amt10;
        this.c_date10 = src.c_date10;
        this.p_amt10 = src.p_amt10;
        this.pur_d11 = src.pur_d11;
        this.acq_d11 = src.acq_d11;
        this.des_c11 = src.des_c11;
        this.f_amt11 = src.f_amt11;
        this.c_date11 = src.c_date11;
        this.p_amt11 = src.p_amt11;
        this.pur_d12 = src.pur_d12;
        this.acq_d12 = src.acq_d12;
        this.des_c12 = src.des_c12;
        this.f_amt12 = src.f_amt12;
        this.c_date12 = src.c_date12;
        this.p_amt12 = src.p_amt12;
        this.pur_d13 = src.pur_d13;
        this.acq_d13 = src.acq_d13;
        this.des_c13 = src.des_c13;
        this.f_amt13 = src.f_amt13;
        this.c_date13 = src.c_date13;
        this.p_amt13 = src.p_amt13;
        this.pur_d14 = src.pur_d14;
        this.acq_d14 = src.acq_d14;
        this.des_c14 = src.des_c14;
        this.f_amt14 = src.f_amt14;
        this.c_date14 = src.c_date14;
        this.p_amt14 = src.p_amt14;
        this.pur_d15 = src.pur_d15;
        this.acq_d15 = src.acq_d15;
        this.des_c15 = src.des_c15;
        this.f_amt15 = src.f_amt15;
        this.c_date15 = src.c_date15;
        this.p_amt15 = src.p_amt15;
        this.pur_d16 = src.pur_d16;
        this.acq_d16 = src.acq_d16;
        this.des_c16 = src.des_c16;
        this.f_amt16 = src.f_amt16;
        this.c_date16 = src.c_date16;
        this.p_amt16 = src.p_amt16;
        this.pur_d17 = src.pur_d17;
        this.acq_d17 = src.acq_d17;
        this.des_c17 = src.des_c17;
        this.f_amt17 = src.f_amt17;
        this.c_date17 = src.c_date17;
        this.p_amt17 = src.p_amt17;
        this.pur_d18 = src.pur_d18;
        this.acq_d18 = src.acq_d18;
        this.des_c18 = src.des_c18;
        this.f_amt18 = src.f_amt18;
        this.c_date18 = src.c_date18;
        this.p_amt18 = src.p_amt18;
        this.pur_d19 = src.pur_d19;
        this.acq_d19 = src.acq_d19;
        this.des_c19 = src.des_c19;
        this.f_amt19 = src.f_amt19;
        this.c_date19 = src.c_date19;
        this.p_amt19 = src.p_amt19;
        this.pur_d20 = src.pur_d20;
        this.acq_d20 = src.acq_d20;
        this.des_c20 = src.des_c20;
        this.f_amt20 = src.f_amt20;
        this.c_date20 = src.c_date20;
        this.p_amt20 = src.p_amt20;
        this.pur_d21 = src.pur_d21;
        this.acq_d21 = src.acq_d21;
        this.des_c21 = src.des_c21;
        this.f_amt21 = src.f_amt21;
        this.c_date21 = src.c_date21;
        this.p_amt21 = src.p_amt21;
        this.pur_d22 = src.pur_d22;
        this.acq_d22 = src.acq_d22;
        this.des_c22 = src.des_c22;
        this.f_amt22 = src.f_amt22;
        this.c_date22 = src.c_date22;
        this.p_amt22 = src.p_amt22;
        this.pur_d23 = src.pur_d23;
        this.acq_d23 = src.acq_d23;
        this.des_c23 = src.des_c23;
        this.f_amt23 = src.f_amt23;
        this.c_date23 = src.c_date23;
        this.p_amt23 = src.p_amt23;
        this.pur_d24 = src.pur_d24;
        this.acq_d24 = src.acq_d24;
        this.des_c24 = src.des_c24;
        this.f_amt24 = src.f_amt24;
        this.c_date24 = src.c_date24;
        this.p_amt24 = src.p_amt24;
        this.pur_d25 = src.pur_d25;
        this.acq_d25 = src.acq_d25;
        this.des_c25 = src.des_c25;
        this.f_amt25 = src.f_amt25;
        this.c_date25 = src.c_date25;
        this.p_amt25 = src.p_amt25;
        this.Status = src.Status;
        this.Int_Rec = src.Int_Rec;
    }

    public SRSM002 Clone()
    {
        return new SRSM002 {
            name1 = this.name1,
            name2 = this.name2,
            text1 = this.text1,
            text2 = this.text2,
            addr1 = this.addr1,
            addr2 = this.addr2,
            addr3 = this.addr3,
            branch = this.branch,
            idno = this.idno,
            seq = this.seq,
            ded_amt = this.ded_amt,
            acctno = this.acctno,
            revolve_amt = this.revolve_amt,
            lastpaydate = this.lastpaydate,
            prev_tot_receivable = this.prev_tot_receivable,
            prev_payment = this.prev_payment,
            print_date = this.print_date,
            page = this.page,
            o_amt = this.o_amt,
            pre_p_amt = this.pre_p_amt,
            c_amt = this.c_amt,
            p_amt = this.p_amt,
            d_amt = this.d_amt,
            e_amt = this.e_amt,
            f_amt = this.f_amt,
            r_amt = this.r_amt,
            pay_amt = this.pay_amt,
            min_pay_amt = this.min_pay_amt,
            g1_msg = this.g1_msg,
            g2_msg = this.g2_msg,
            g3_msg = this.g3_msg,
            g4_msg = this.g4_msg,
            acct_yymm = this.acct_yymm,
            last_tot_dot = this.last_tot_dot,
            curr_dot = this.curr_dot,
            use_dot = this.use_dot,
            this_tot_dot = this.this_tot_dot,
            atm_acct_no = this.atm_acct_no,
            acctno_bank = this.acctno_bank,
            public_amt = this.public_amt,
            delq_flag = this.delq_flag,
            birth_flag = this.birth_flag,
            Other_flag = this.Other_flag,
            pur_d01 = this.pur_d01,
            acq_d01 = this.acq_d01,
            des_c01 = this.des_c01,
            f_amt01 = this.f_amt01,
            c_date01 = this.c_date01,
            p_amt01 = this.p_amt01,
            pur_d02 = this.pur_d02,
            acq_d02 = this.acq_d02,
            des_c02 = this.des_c02,
            f_amt02 = this.f_amt02,
            c_date02 = this.c_date02,
            p_amt02 = this.p_amt02,
            pur_d03 = this.pur_d03,
            acq_d03 = this.acq_d03,
            des_c03 = this.des_c03,
            f_amt03 = this.f_amt03,
            c_date03 = this.c_date03,
            p_amt03 = this.p_amt03,
            pur_d04 = this.pur_d04,
            acq_d04 = this.acq_d04,
            des_c04 = this.des_c04,
            f_amt04 = this.f_amt04,
            c_date04 = this.c_date04,
            p_amt04 = this.p_amt04,
            pur_d05 = this.pur_d05,
            acq_d05 = this.acq_d05,
            des_c05 = this.des_c05,
            f_amt05 = this.f_amt05,
            c_date05 = this.c_date05,
            p_amt05 = this.p_amt05,
            pur_d06 = this.pur_d06,
            acq_d06 = this.acq_d06,
            des_c06 = this.des_c06,
            f_amt06 = this.f_amt06,
            c_date06 = this.c_date06,
            p_amt06 = this.p_amt06,
            pur_d07 = this.pur_d07,
            acq_d07 = this.acq_d07,
            des_c07 = this.des_c07,
            f_amt07 = this.f_amt07,
            c_date07 = this.c_date07,
            p_amt07 = this.p_amt07,
            pur_d08 = this.pur_d08,
            acq_d08 = this.acq_d08,
            des_c08 = this.des_c08,
            f_amt08 = this.f_amt08,
            c_date08 = this.c_date08,
            p_amt08 = this.p_amt08,
            pur_d09 = this.pur_d09,
            acq_d09 = this.acq_d09,
            des_c09 = this.des_c09,
            f_amt09 = this.f_amt09,
            c_date09 = this.c_date09,
            p_amt09 = this.p_amt09,
            pur_d10 = this.pur_d10,
            acq_d10 = this.acq_d10,
            des_c10 = this.des_c10,
            f_amt10 = this.f_amt10,
            c_date10 = this.c_date10,
            p_amt10 = this.p_amt10,
            pur_d11 = this.pur_d11,
            acq_d11 = this.acq_d11,
            des_c11 = this.des_c11,
            f_amt11 = this.f_amt11,
            c_date11 = this.c_date11,
            p_amt11 = this.p_amt11,
            pur_d12 = this.pur_d12,
            acq_d12 = this.acq_d12,
            des_c12 = this.des_c12,
            f_amt12 = this.f_amt12,
            c_date12 = this.c_date12,
            p_amt12 = this.p_amt12,
            pur_d13 = this.pur_d13,
            acq_d13 = this.acq_d13,
            des_c13 = this.des_c13,
            f_amt13 = this.f_amt13,
            c_date13 = this.c_date13,
            p_amt13 = this.p_amt13,
            pur_d14 = this.pur_d14,
            acq_d14 = this.acq_d14,
            des_c14 = this.des_c14,
            f_amt14 = this.f_amt14,
            c_date14 = this.c_date14,
            p_amt14 = this.p_amt14,
            pur_d15 = this.pur_d15,
            acq_d15 = this.acq_d15,
            des_c15 = this.des_c15,
            f_amt15 = this.f_amt15,
            c_date15 = this.c_date15,
            p_amt15 = this.p_amt15,
            pur_d16 = this.pur_d16,
            acq_d16 = this.acq_d16,
            des_c16 = this.des_c16,
            f_amt16 = this.f_amt16,
            c_date16 = this.c_date16,
            p_amt16 = this.p_amt16,
            pur_d17 = this.pur_d17,
            acq_d17 = this.acq_d17,
            des_c17 = this.des_c17,
            f_amt17 = this.f_amt17,
            c_date17 = this.c_date17,
            p_amt17 = this.p_amt17,
            pur_d18 = this.pur_d18,
            acq_d18 = this.acq_d18,
            des_c18 = this.des_c18,
            f_amt18 = this.f_amt18,
            c_date18 = this.c_date18,
            p_amt18 = this.p_amt18,
            pur_d19 = this.pur_d19,
            acq_d19 = this.acq_d19,
            des_c19 = this.des_c19,
            f_amt19 = this.f_amt19,
            c_date19 = this.c_date19,
            p_amt19 = this.p_amt19,
            pur_d20 = this.pur_d20,
            acq_d20 = this.acq_d20,
            des_c20 = this.des_c20,
            f_amt20 = this.f_amt20,
            c_date20 = this.c_date20,
            p_amt20 = this.p_amt20,
            pur_d21 = this.pur_d21,
            acq_d21 = this.acq_d21,
            des_c21 = this.des_c21,
            f_amt21 = this.f_amt21,
            c_date21 = this.c_date21,
            p_amt21 = this.p_amt21,
            pur_d22 = this.pur_d22,
            acq_d22 = this.acq_d22,
            des_c22 = this.des_c22,
            f_amt22 = this.f_amt22,
            c_date22 = this.c_date22,
            p_amt22 = this.p_amt22,
            pur_d23 = this.pur_d23,
            acq_d23 = this.acq_d23,
            des_c23 = this.des_c23,
            f_amt23 = this.f_amt23,
            c_date23 = this.c_date23,
            p_amt23 = this.p_amt23,
            pur_d24 = this.pur_d24,
            acq_d24 = this.acq_d24,
            des_c24 = this.des_c24,
            f_amt24 = this.f_amt24,
            c_date24 = this.c_date24,
            p_amt24 = this.p_amt24,
            pur_d25 = this.pur_d25,
            acq_d25 = this.acq_d25,
            des_c25 = this.des_c25,
            f_amt25 = this.f_amt25,
            c_date25 = this.c_date25,
            p_amt25 = this.p_amt25,
            Status = this.Status,
            Int_Rec = this.Int_Rec,
        };
    }
}
}

