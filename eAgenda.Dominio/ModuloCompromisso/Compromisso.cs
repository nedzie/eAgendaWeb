using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloContato;
using System;
using System.Collections.Generic;

namespace eAgenda.Dominio.ModuloCompromisso
{
    public class Compromisso : EntidadeBase<Compromisso>
    {
        private DateTime _date;
        private TipoLocalizacaoCompromissoEnum tipoLocalizacaoCompromisso;
        public Compromisso()
        {
            Data = DateTime.Now;
            HoraInicio = Data.TimeOfDay;
            HoraTermino = Data.TimeOfDay;
        }

        public Compromisso(string assunto, string local, string link, DateTime data,
             TimeSpan horaInicio, TimeSpan horaTermino, Contato contato)
        {
            Assunto = assunto;
            Local = local;
            Link = link;
            Data = data;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            Contato = contato;
        }

        public string Assunto { get; set; }
        public string Local { get; set; }

        public TipoLocalizacaoCompromissoEnum TipoLocalizacaoCompromisso
        {
            get { return tipoLocalizacaoCompromisso; }
            set
            {
                tipoLocalizacaoCompromisso = value;

                switch (tipoLocalizacaoCompromisso)
                {
                    case TipoLocalizacaoCompromissoEnum.Presencial: Link = null; break;
                    case TipoLocalizacaoCompromissoEnum.Remoto: Local = null; break;

                    default:
                        break;
                }
            }
        }

        public string Link { get; set; }
        public DateTime Data { get { return _date.Date; } set { _date = value; } }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }
        public Contato Contato { get; set; }
        public Guid? ContatoId { get; set; }

        public override void Atualizar(Compromisso registro)
        {
            Id = registro.Id;
            Assunto = registro.Assunto;
            Local = registro.Local;
            Link = registro.Link;
            Data = registro.Data;
            HoraInicio = registro.HoraInicio;
            HoraTermino = registro.HoraTermino;
            Contato = registro.Contato;
        }

        public override bool Equals(object obj)
        {
            return obj is Compromisso compromisso &&
                   Id == compromisso.Id &&
                   Assunto == compromisso.Assunto &&
                   Local == compromisso.Local &&
                   TipoLocalizacaoCompromisso == compromisso.TipoLocalizacaoCompromisso &&
                   Link == compromisso.Link &&
                   Data == compromisso.Data &&
                   HoraInicio.Equals(compromisso.HoraInicio) &&
                   HoraTermino.Equals(compromisso.HoraTermino) &&
                   EqualityComparer<Contato>.Default.Equals(Contato, compromisso.Contato);
        }

        public Compromisso Clonar()
        {
            return MemberwiseClone() as Compromisso;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Id);
            hash.Add(Assunto);
            hash.Add(Local);
            hash.Add(TipoLocalizacaoCompromisso);
            hash.Add(Link);
            hash.Add(Data);
            hash.Add(HoraInicio);
            hash.Add(HoraTermino);
            hash.Add(Contato);
            return hash.ToHashCode();
        }
    }
}
